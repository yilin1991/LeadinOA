using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Leadin.OA.oasystem.oaorder
{
    public partial class edit : Leadin.Web.UI.ManagePage
    {

        BLL.Customer bllCustomer = new BLL.Customer();
        BLL.Paper bllPaper = new BLL.Paper();
        BLL.PublicVersion bllPublicversion = new BLL.PublicVersion();
        BLL.Technology bllTechnology = new BLL.Technology();


        BLL.FatherOrder bllFathrt = new BLL.FatherOrder();
        BLL.SonOrder bllSonOrder = new BLL.SonOrder();
        BLL.OrdeTechnology bllOrderTechnology = new BLL.OrdeTechnology();
        BLL.OrdeDistribution bllDistribution = new BLL.OrdeDistribution();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomer();
                BindPaper();
                BindddlType(10017, ddlDelivery, true);
                BindddlType(10014, ddlType, true);
                BindTechnology();
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
                DataSet dsSub = bllCustomer.GetList(0, "ParentId=" + item["Id"].ToString() + " and StateInfo=1", "AddTime asc,Id asc");
                if (dsSub.Tables[0].Rows.Count > 0)
                {
                    ddlCustomer.Items.Add(new ListItem(item["CompanyName"].ToString(), ""));
                    foreach (DataRow item1 in dsSub.Tables[0].Rows)
                    {
                        ddlCustomer.Items.Add(new ListItem("　|--" + item1["CompanyName"].ToString(), item1["Id"].ToString()));
                    }
                }
                else
                {
                    ddlCustomer.Items.Add(new ListItem(item["CompanyName"].ToString(), item["Id"].ToString()));
                }
            }
        }


        /// <summary>
        /// 绑定纸张
        /// </summary>
        void BindPaper()
        {
            DataSet ds = bllPaper.GetList(0, "StateInfo=1", "SortNum desc,Id asc");

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ddlPaper.Items.Add(new ListItem(item["NameInfo"].ToString() + "(" + item["PaperSpec"].ToString() + ")", item["Id"].ToString()));
            }

        }


        /// <summary>
        /// 绑定工艺
        /// </summary>
        void BindTechnology()
        {

            DataSet ds = bllTechnology.GetList(0, "StateInfo=1 and ParentId=0", "SortNum desc,Id asc");

            repTechnology.DataSource = ds;
            repTechnology.DataBind();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                HiddenField hidId = repTechnology.Items[i].FindControl("hidId") as HiddenField;
                Repeater repSubTechnology = repTechnology.Items[i].FindControl("repSubTechnology") as Repeater;
                repSubTechnology.DataSource = bllTechnology.GetList(0, "StateInfo=1 and ParentId=" + ds.Tables[0].Rows[i]["Id"].ToString(), "SortNum desc,Id asc");
                repSubTechnology.DataBind();
            }
        }




        /// <summary>
        /// 确认提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnOK_Click(object sender, EventArgs e)
        {

            int fathrtId = AddFathrtNum();

            if (fathrtId > 0)
            {

            }



        }



        /// <summary>
        /// 添加公司订单
        /// </summary>
        /// <returns></returns>
        int AddFathrtNum()
        {
            Model.Customer modelCustomer = bllCustomer.GetModel(int.Parse(ddlCustomer.SelectedValue));
            int fathrtId;//直接客户当天订单好
            int customerId;//获取直接客户编号
            if (modelCustomer.ParentId == 0)//直接客户下单
            {
                customerId = modelCustomer.Id;
            }
            else//非直接客户下单
            {
                customerId = modelCustomer.ParentId;
            }
            DataSet ds = bllFathrt.GetList("CustomerId=" + customerId + " and AddTime>Convert(datetime,'" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00" + "') and Convert(datetime,AddTime) <= Convert(datetime,'" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59" + "')");
            //" and O_AddTime "
            if (ds.Tables[0].Rows.Count > 0)//已经存在订单了
            {
                fathrtId = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
            }
            else//不存在订单
            {
                Model.FatherOrder modelFather = new Model.FatherOrder();
                modelFather.NumId = SetFathrtNumID();
                if (!string.IsNullOrEmpty(ddlAddress.SelectedValue))
                {
                    modelFather.AddressId = int.Parse(ddlAddress.SelectedValue);
                }
                modelFather.AddTime = DateTime.Now;
                modelFather.CustomerId = customerId;
                modelFather.StateInfo = 10022;
                modelFather.WorkersId = int.Parse(Session["AdminId"].ToString());
                fathrtId = bllFathrt.Add(modelFather);

            }
            return fathrtId;
        }


        /// <summary>
        /// 添加客户订单
        /// </summary>
        /// <param name="fathrtId"></param>
        /// <returns></returns>
        int AddSonOrder(int fathrtId)
        {

            Model.SonOrder model = new Model.SonOrder();
            model.AddTime = DateTime.Now;
            model.DifferencePrice = decimal.Parse(txtDifferencePrice.Text);
            model.DifferenceReason = txtDifferenceReason.Text;
            model.Explain = txtExplain.Text;
            model.FatherOrderId = fathrtId;
            model.Num = decimal.Parse(txtNum.Text);
            model.NumId = SetSonNumID(fathrtId);
            model.PaperId = int.Parse(ddlPaper.SelectedValue);
            if (!string.IsNullOrEmpty(ddlPublicversion.SelectedValue))
            {
                model.PublicVersionId = int.Parse(ddlPublicversion.SelectedValue);
            }
            model.StateInfo = 10022;
            model.TypeId = int.Parse(ddlType.SelectedValue);
            model.WorkersId = int.Parse(Session["AdminId"].ToString());


            return bllSonOrder.Add(model);
        }



        /// <summary>
        /// 添加订单工艺
        /// </summary>
        /// <param name="sonId"></param>
        void AddTechnology(int sonId)
        {
            Model.OrdeTechnology model = new Model.OrdeTechnology();

            for (int i = 0; i < repTechnology.Items.Count; i++)
            {
                Repeater repSubTechnology = repTechnology.Items[i].FindControl("repSubTechnology") as Repeater;

                for (int j = 0; j < repSubTechnology.Items.Count; j++)
                {
                    CheckBox ckTechnology = repSubTechnology.Items[j].FindControl("ckTechnology") as CheckBox;

                    if (ckTechnology.Checked)
                    {
                        HiddenField hidsubId = repSubTechnology.Items[j].FindControl("hidsubId") as HiddenField;
                        HiddenField hidPrice = repSubTechnology.Items[j].FindControl("hidPrice") as HiddenField;
                        model.Price = decimal.Parse(hidPrice.Value);
                        model.SonOrderId = sonId;
                        model.TechnologyId = int.Parse(hidsubId.Value);
                        bllOrderTechnology.Add(model);
                    }
                }
            }
        }


        /// <summary>
        /// 添加订单配送信息
        /// </summary>
        /// <param name="fathrtid"></param>
        void AddDistribution(int fathrtid)
        {
            Model.OrdeDistribution model = new Model.OrdeDistribution();

          

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



        /// <summary>
        /// 获取客户订单编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SetSonNumID(int fathrtId)
        {
            Model.FatherOrder model = bllFathrt.GetModel(fathrtId);

            StringBuilder strNumId = new StringBuilder();
            strNumId.Append(model.NumId);
            strNumId.Append("-");
            DataSet ds = bllSonOrder.GetList(0, "FatherOrderId=" + fathrtId, "NumId desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                strNumId.Append(int.Parse(ds.Tables[0].Rows[0]["NumId"].ToString().Split('-')[1]).ToString().PadLeft(3, '0'));
            }
            else
            {
                strNumId.Append("0001");
            }
            return strNumId.ToString();

        }


    }
}