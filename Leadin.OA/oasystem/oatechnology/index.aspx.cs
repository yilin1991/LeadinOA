using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oatechnology
{
    public partial class index : Leadin.Web.UI.ManagePage
    {
        BLL.Technology bll = new BLL.Technology();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepList();
            }
        }


        /// <summary>
        /// 绑定工艺列表
        /// </summary>
        void BindRepList()
        {
            repList.DataSource = bll.GetList(0, "", "SortNum desc,AddTime asc");
            repList.DataBind();
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
        /// 绑定所属工艺
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public string GetParentName(int pid)
        {
            if (string.Equals(pid, 0))
            {
                return "顶级工艺";
            }
            else
            {
                Model.Technology model = bll.GetModel(pid);

                if (model != null)
                {
                    return model.NameInfo;
                }
                else
                {
                    return "未找到所属工艺";
                }

            }
        }


    }
}