using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oaworkers
{
    public partial class index : Leadin.Web.UI.ManagePage
    {

        BLL.Workers bll = new BLL.Workers();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepList();
            }
        }


        /// <summary>
        /// 绑定人员列表
        /// </summary>
        void BindRepList()
        {
            repList.DataSource = bll.GetList(0, "", "AddTime desc");
            repList.DataBind();
        }




        /// <summary>
        /// 添加人员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}