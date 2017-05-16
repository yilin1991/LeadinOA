using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oacustomer
{
    public partial class index : Leadin.Web.UI.ManagePage
    {

        BLL.Customer bll = new BLL.Customer();
        Model.Customer model = new Model.Customer();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepList();
            }
        }


        /// <summary>
        /// 绑定客户列表
        /// </summary>
        void BindRepList()
        {
            repList.DataSource = bll.GetList(0, "", "AddTime asc");
            repList.DataBind();
        }


        /// <summary>
        /// 获取所属公司名称
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public string GetPartentCompany(int pid)
        {
            if (string.Equals(pid, 0))
            {
                return "直接客户";
            }
            else
            {
                model = bll.GetModel(pid);

                if (model != null)
                {
                    return model.CompanyName;
                }
                else
                {
                    return "未找到所属公司";
                }
            }
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("edit.aspx");
        }



        /// <summary>
        /// 属性修改
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "lbtnAddress")
            {
                HiddenField hidId = e.Item.FindControl("hidId") as HiddenField;
                Response.Redirect("address-index.aspx?cid=" + hidId.Value);
            }
            if (e.CommandName == "lbtnpublicversion")
            {
                HiddenField hidId = e.Item.FindControl("hidId") as HiddenField;

                Response.Redirect("/oasystem/oapublicversion/index.aspx?cid=" + hidId.Value);
            }
        }
    }
}