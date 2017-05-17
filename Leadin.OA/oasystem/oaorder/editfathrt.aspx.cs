using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oaorder
{
    public partial class editfathrt : Leadin.Web.UI.ManagePage
    {
        BLL.FatherOrder bllFathrt = new BLL.FatherOrder();
        BLL.Customer bllCustomer = new BLL.Customer();
        BLL.Distribution bllDistribution = new BLL.Distribution();
        BLL.OrdeDistribution bllOrderDistribution = new BLL.OrdeDistribution();


        public string checkorder = "/Tools/CheckOrder.ashx";

        int fid;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomer();
                BindddlType(10017, ddlDelivery, true);


                if (int.TryParse(Request.Params["fid"], out fid))
                {
                    BindDetail(fid);
                }


            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="fid"></param>
        void BindDetail(int fid)
        {
            Model.FatherOrder modelorder = bllFathrt.GetModel(fid);
            ddlCustomer.SelectedValue = modelorder.CustomerId.ToString();
            BindAddress(int.Parse(modelorder.CustomerId.ToString()));
            List<Model.OrdeDistribution> modelOD = bllOrderDistribution.GetModelList("OrderId=" + fid);

            ddlAddress.SelectedValue = modelorder.AddressId.ToString();
            ddlDelivery.SelectedValue = modelOD[0].TypeId.ToString();
            BindDeliverystaff(modelOD[0].TypeId);
            if (modelOD[0].TypeId == 10018)
            {

                ddlDeliverystaff.SelectedValue = modelOD[0].WorkersId.ToString();
            }
            if (modelOD[0].TypeId == 10019)
            {
                ddlDeliverystaff.SelectedValue = modelOD[0].DistributionId.ToString();
            }
            txtDeliveryNum.Text = modelOD[0].DistributionNum;

            ddlPriceType.SelectedValue = modelOD[0].PriceType.ToString();
            txtExplain.Text = modelorder.Remark;

            checkorder = "";
        }


        /// <summary>
        /// 绑定收货人信息
        /// </summary>
        void BindAddress(int CustimerId)
        {
            BLL.CustomerAddress blladdress = new BLL.CustomerAddress();

            DataSet ds = blladdress.GetList("CustimerId=" + CustimerId);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ddlAddress.Items.Add(new ListItem(item["NameInfo"].ToString() + ", " + item["Addressinfo"].ToString() + ", " + item["Phone"].ToString(), item["Id"].ToString()));
            }

        }

        /// <summary>
        /// 绑定配送人信息
        /// </summary>
        void BindDeliverystaff(int typeId)
        {
            switch (typeId)
            {
                case 10018://公司配送
                    BLL.Workers bllWorker = new BLL.Workers();
                    DataSet ds = bllWorker.GetList("StateInfo=1 and TypeId=10027");

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        ddlDeliverystaff.Items.Add(new ListItem(item["NameInfo"].ToString(), item["Id"].ToString()));
                    }
                    break;
                case 10019://快递配送
                    BLL.Distribution bllDistribution = new BLL.Distribution();
                    DataSet dsDistribution = bllDistribution.GetList("StateInfo=1");
                    foreach (DataRow item in dsDistribution.Tables[0].Rows)
                    {
                        ddlDeliverystaff.Items.Add(new ListItem(item["CompanyName"].ToString(), item["Id"].ToString()));
                    }
                    break;
            }

        }



        /// <summary>
        /// 绑定客户下拉列表
        /// </summary>
        void BindCustomer()
        {
            DataSet ds = bllCustomer.GetList(0, "ParentId=0 and StateInfo=1", "AddTime asc,Id asc");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ddlCustomer.Items.Add(new ListItem(item["CompanyName"].ToString(), item["Id"].ToString()));

            }
        }



        /// <summary>
        /// 确认提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {
            bool isEdit = false;
            int did = 0;
            Model.FatherOrder modelFather = new Model.FatherOrder();
            if (int.TryParse(Request.Params["fid"], out fid))
            {
                modelFather = bllFathrt.GetModel(fid);
                did = modelFather.Id;
                isEdit = true;
            }
            else
            {
                DataSet ds = bllFathrt.GetList("CustomerId=" + ddlCustomer.SelectedValue + " and AddTime>Convert(datetime,'" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00" + "') and Convert(datetime,AddTime) <= Convert(datetime,'" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59" + "')");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    modelFather = bllFathrt.GetModel(int.Parse(ds.Tables[0].Rows[0]["Id"].ToString()));
                    isEdit = true;
                }
                else
                {
                    modelFather.AddTime = DateTime.Now;
                    modelFather.NumId = SetFathrtNumID();
                    modelFather.MoneyState = 0;
                }

            }

            if (!string.IsNullOrEmpty(Request.Form["ddlAddress"]))
            {
                modelFather.AddressId = int.Parse(Request.Form["ddlAddress"]);
               
            }
          
            modelFather.CustomerId = int.Parse(ddlCustomer.SelectedValue);
            modelFather.StateInfo = 10022;
            modelFather.WorkersId = int.Parse(Session["AdminId"].ToString());
            modelFather.Remark = txtExplain.Text;



            if (!isEdit)
            {
                did = bllFathrt.Add(modelFather);
            }
            else
            {
                bllFathrt.Update(modelFather);
            }


            AddDistribution(did);

            JsMessage("公司订单添加成功", 2000, "true","index.aspx");
            

        }





        /// <summary>
        /// 添加订单配送信息
        /// </summary>
        /// <param name="fathrtid">公司订单编号</param>
        void AddDistribution(int fathrtid)
        {

            bool isEdit = false;
            Model.OrdeDistribution model = new Model.OrdeDistribution();
            DataSet ds = bllOrderDistribution.GetList("OrderId=" + fathrtid);
            if (ds.Tables[0].Rows.Count > 0)
            {
                isEdit = true;
                model = bllOrderDistribution.GetModel(int.Parse(ds.Tables[0].Rows[0]["Id"].ToString()));
            }
            model.OrderId = fathrtid;
            model.PriceType = int.Parse(ddlPriceType.SelectedValue);
            model.TypeId = int.Parse(ddlDelivery.SelectedValue);
            model.DistributionNum = txtDeliveryNum.Text;
            model.Price = 0;
            switch (ddlDelivery.SelectedValue)
            {
                case "10018"://公司配送
                    if (!string.IsNullOrEmpty(Request.Form["ddlDeliverystaff"]))
                    {
                        model.WorkersId = int.Parse(Request.Form["ddlDeliverystaff"]);
                    }
                    break;
                case "10019"://快递信息
                    if (!string.IsNullOrEmpty(Request.Form["ddlDeliverystaff"]))
                    {
                        model.DistributionId = int.Parse(Request.Form["ddlDeliverystaff"]);
                        Model.Distribution modelDis = bllDistribution.GetModel(int.Parse(Request.Form["ddlDeliverystaff"]));
                        if (ddlPriceType.SelectedValue == "0")
                        {
                            model.Price = modelDis.Price;
                        }
                    }
                    break;
            }

            if (isEdit)
            {
                bllOrderDistribution.Update(model);
            }
            else
            {
                bllOrderDistribution.Add(model);
            }
        }


        /// <summary>
        /// 设置公司订单编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SetFathrtNumID()
        {
            StringBuilder strNumId = new StringBuilder("OAO");
            strNumId.Append(DateTime.Now.ToString("yyMMdd"));
            Model.FatherOrder model = bllFathrt.GetModel(bllFathrt.GetMaxId());
            if (model != null)
            {
                strNumId.Append((int.Parse(model.NumId.Substring(model.NumId.Length - 4)) + 1).ToString().PadLeft(4, '0'));
            }
            else
            {
                strNumId.Append("0001");
            }
            return strNumId.ToString();

        }


    }
}