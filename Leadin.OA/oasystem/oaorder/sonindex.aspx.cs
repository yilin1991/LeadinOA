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

    public partial class sonindex : Leadin.Web.UI.ManagePage
    {

        BLL.SonOrder bll = new BLL.SonOrder();

        int fid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.Params["fid"], out fid))
                {

                    BindRepList();
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }



        /// <summary>
        /// 绑定子订单列表
        /// </summary>
        void BindRepList()
        {

            StringBuilder strWhere = new StringBuilder();

            if (!string.IsNullOrEmpty(Request.Params["fid"]))
            {
                strWhere.Append("FatherOrderId=" + Request.Params["fid"]);
            }

            repList.DataSource = bll.GetList(strWhere.ToString());
            repList.DataBind();



        }





        /// <summary>
        /// 获取公司名称
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public string GetCompany(int customerId)
        {
            BLL.Customer bllCustomer = new BLL.Customer();
            Model.Customer model = bllCustomer.GetModel(customerId);
            if (model.ParentId == 0)
            {
                return model.CompanyName == "" ? "--" : model.CompanyName;
            }
            else
            {
                return bllCustomer.GetModel(model.ParentId).CompanyName;
            }

        }




        /// <summary>
        /// 获取客户名称
        /// </summary>
        /// <returns></returns>
        public string GetCustomerName(int customer)
        {
            BLL.Customer bllCustomer = new BLL.Customer();
            Model.Customer model = bllCustomer.GetModel(customer);
            if (string.IsNullOrEmpty(model.CompanyName))
            {
                return "--";
            }
            else
            {
                return model.CompanyName;
            }
        }
        /// <summary>
        /// 获取公版名称
        /// </summary>
        /// <returns></returns>
        public string GetCustomerName(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return "--";
            }
            else
            {
                BLL.PublicVersion bllCustomer = new BLL.PublicVersion();
                Model.PublicVersion model = bllCustomer.GetModel(int.Parse(id));
                if (string.IsNullOrEmpty(model.NameInfo))
                {
                    return "--";
                }
                else
                {
                    return model.NameInfo;
                }
            }
        }



        /// <summary>
        /// 获取印刷工艺
        /// </summary>
        /// <returns></returns>
        public string GetTechnology(int sonId)
        {
            BLL.OrdeTechnology bllTechnology = new BLL.OrdeTechnology();

            DataSet ds = bllTechnology.GetList("SonOrderId="+sonId);

            StringBuilder str = new StringBuilder();

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                str.Append(GetTechnologyName(int.Parse(item["TechnologyId"].ToString()))+" / ");
            }


            return Common.Utils.DelLastChar( str.ToString(),"/");


        }

        public string GetTechnologyName(int id)
        {
            BLL.Technology bllTechnology = new BLL.Technology();
            Model.Technology model = bllTechnology.GetModel(id);

            return bllTechnology.GetModel(model.ParentId).NameInfo + ":" + model.NameInfo;


        }


        /// <summary>
        /// 获取下单员姓名
        /// </summary>
        /// <param name="workerId"></param>
        /// <returns></returns>
        public string GetWorkerName(int workerId)
        {
            BLL.Workers bllWorker = new BLL.Workers();

            return bllWorker.GetModel(workerId).NameInfo;
        }



        /// <summary>
        /// 获取纸张名称
        /// </summary>
        /// <returns></returns>
        public string GetPaperName(int pid)
        {
            BLL.Paper bllPaper = new BLL.Paper();
            Model.Paper model = bllPaper.GetModel(pid);
            if (string.IsNullOrEmpty(model.NameInfo))
            {
                return "--";
            }
            else
            {
                return model.NameInfo;
            }
        }

           
        /// <summary>
        /// 编辑订单
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hidid = e.Item.FindControl("hidid") as HiddenField;

            if (e.CommandName == "lbtnedit")
            {
                Response.Redirect("editson.aspx?sid=" + hidid.Value+"&fid="+Request.Params["fid"]);
            }
        }


        /// <summary>
        /// 返回公司订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnBackOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx"+Request.Url.Query);
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("editson.aspx?fid=" + Request.Params["fid"]);
        }
    }

}