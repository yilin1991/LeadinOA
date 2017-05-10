using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oasystem
{
    public partial class index : Leadin.Web.UI.ManagePage
    {

        BLL.Category bll = new BLL.Category();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepList();
            }
        }


        /// <summary>
        /// 绑定列表
        /// </summary>
        void BindRepList()
        {
            repList.DataSource = bll.GetList(0, "", "SortNum desc,Id asc");
            repList.DataBind();
        }


        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("edit.aspx");
        }
    }
}