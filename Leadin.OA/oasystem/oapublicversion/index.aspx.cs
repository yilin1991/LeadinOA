﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oapublicversion
{
    public partial class index : Leadin.Web.UI.ManagePage
    {
        BLL.PublicVersion bll = new BLL.PublicVersion();
        public int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.Params["cid"], out id))
                {
                    BindRepList(id);
                }
                else
                {
                    Response.Redirect("/oasystem/oacustomer/index.aspx");
                }
            }
        }


        /// <summary>
        /// 绑定公版列表
        /// </summary>
        void BindRepList(int cid)
        {
            repList.DataSource = bll.GetList(0, "CustomerId=" + id, "SortNum desc,Id asc");
            repList.DataBind();
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("edit.aspx?cid="+Request.Params["cid"]);
        }
    }
}