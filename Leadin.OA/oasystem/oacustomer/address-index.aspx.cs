using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oacustomer
{
    public partial class address_index : Leadin.Web.UI.ManagePage
    {
        BLL.CustomerAddress bll = new BLL.CustomerAddress();

       public  int cid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.Params["cid"], out cid))
                {
                    BindReplist(cid);
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
        }


        /// <summary>
        /// 绑定列表
        /// </summary>
        /// <param name="id"></param>
        void BindReplist(int id)
        {
            repList.DataSource = bll.GetList(0, "CustimerId="+id, "Id desc");
            repList.DataBind();
        }



        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("address-edit.aspx?cid=" + Request.Params["cid"]);
        }
    }
}