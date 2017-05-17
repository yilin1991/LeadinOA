using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Leadin.OA.oasystem.oaorder
{
    public partial class index : Leadin.Web.UI.ManagePage
    {
        BLL.FatherOrder bllorder = new BLL.FatherOrder();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindddlType(10021, ddlStateInfo, true);

                BindRepList();
            }
        }


        /// <summary>
        /// 绑定公司订单详情
        /// </summary>
        void BindRepList()
        {
            repList.DataSource = bllorder.GetList(0, "", "AddTime desc");
            repList.DataBind();
        }


        /// <summary>
        /// 获取公司名称
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public string GetCustomerName(int customerId)
        {
            BLL.Customer bll = new BLL.Customer();

            Model.Customer model = bll.GetModel(customerId);

            if (string.IsNullOrEmpty(model.CompanyName))
            {
                return "未找到公司";
            }
            else
            {
                return model.CompanyName;
            }


        }


        /// <summary>
        /// 获取收获地址详细信息
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public string GetAddressDetail(string addressId)
        {
            if (string.IsNullOrEmpty(addressId))
            {
                return "--";
            }
            else
            {
                BLL.CustomerAddress bll = new BLL.CustomerAddress();

                Model.CustomerAddress model = bll.GetModel(int.Parse(addressId));

                if (model != null)
                {
                    return model.Addressinfo + ", " + model.NameInfo + ", " + model.Phone;
                }
                else
                {
                    return "--";
                }
            }

        }


        /// <summary>
        /// 获取配送信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public string[] GetDisDistribution(int orderId)
        {
            BLL.OrdeDistribution bll = new BLL.OrdeDistribution();
            BLL.Workers bllWorkers = new BLL.Workers();
            BLL.Distribution bllDistribution = new BLL.Distribution();
            string[] strDis = new string[4];
            DataSet ds = bll.GetList("OrderId=" + orderId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                strDis[0] = GetCategoryName(int.Parse(ds.Tables[0].Rows[0]["TypeId"].ToString()));

                if (ds.Tables[0].Rows[0]["TypeId"].ToString() == "10018")//公司配送
                {
                    if (ds.Tables[0].Rows[0]["WorkersId"].ToString() == "")
                    {
                        strDis[1] = "--";
                    }
                    else
                    {
                        strDis[1] = bllWorkers.GetModel(int.Parse(ds.Tables[0].Rows[0]["WorkersId"].ToString())).NameInfo;
                    }
                }
                else if (ds.Tables[0].Rows[0]["TypeId"].ToString() == "10019")//快递配送
                {
                    if (ds.Tables[0].Rows[0]["DistributionId"].ToString() == "")
                    {
                        strDis[1] = "--";
                    }
                    else
                    {
                        strDis[1] = bllDistribution.GetModel(int.Parse(ds.Tables[0].Rows[0]["DistributionId"].ToString())).CompanyName;
                    }
                }
                else
                {
                    strDis[1] = "--";
                }
                strDis[2] = ds.Tables[0].Rows[0]["DistributionNum"].ToString() == "" ? "--" : ds.Tables[0].Rows[0]["DistributionNum"].ToString();
                strDis[3] = ds.Tables[0].Rows[0]["PriceType"].ToString() == "1" ? "非到付" : "到付";
            }
            else
            {
                strDis[0] = "--";//配送类型
                strDis[1] = "--";//配送人
                strDis[2] = "--";//快递单号
                strDis[3] = "--";//快递费用
            }

            return strDis;

        }


        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("editfathrt.aspx");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            HiddenField hidfid = e.Item.FindControl("hidfid") as HiddenField;

            if (e.CommandName == "lbtnDistribution")//修改配送信息
            {
                Response.Redirect("editfathrt.aspx?fid=" + hidfid.Value);
            }
            if (e.CommandName == "lbtnSonOrder")//查看子订单
            {
                Response.Redirect("sonindex.aspx?fid=" + hidfid.Value);
            }
        }



        /// <summary>
        /// 标记为已付款
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnMoney_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < repList.Items.Count; i++)
            {
                CheckBox ckChecked = repList.Items[i].FindControl("ckChecked") as CheckBox;

                if (ckChecked.Checked)
                {
                    HiddenField hidfid = repList.Items[i].FindControl("hidfid") as HiddenField;

                    Model.FatherOrder model = bllorder.GetModel(int.Parse(hidfid.Value));
                    model.MoneyState = 1;
                    bllorder.Update(model);
                }

            }

            BindRepList();


        }


        
        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnState_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlStateInfo.SelectedValue))
            {
                for (int i = 0; i < repList.Items.Count; i++)
                {
                    CheckBox ckChecked = repList.Items[i].FindControl("ckChecked") as CheckBox;

                    if (ckChecked.Checked)
                    {
                        HiddenField hidfid = repList.Items[i].FindControl("hidfid") as HiddenField;

                        Model.FatherOrder model = bllorder.GetModel(int.Parse(hidfid.Value));
                        model.StateInfo = int.Parse(ddlStateInfo.SelectedValue);
                        bllorder.Update(model);
                    }

                }

                BindRepList();
            }
        }
    }
}