using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Leadin.OA.oasystem.oaorder
{
    public partial class edit : Leadin.Web.UI.ManagePage
    {

        BLL.Customer bllCustomer = new BLL.Customer();
        BLL.Paper bllPaper = new BLL.Paper();
        BLL.PublicVersion bllPublicversion = new BLL.PublicVersion();
        BLL.Technology bllTechnology = new BLL.Technology();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomer();
                BindPaper();
                BindPublicversion();
                BindddlType(10014, ddlType,true);
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
                DataSet dsSub = bllCustomer.GetList(0, "ParentId="+item["Id"].ToString()+" and StateInfo=1", "AddTime asc,Id asc");
                if (dsSub.Tables[0].Rows.Count > 0)
                {
                    ddlCustomer.Items.Add(new ListItem(item["CompanyName"].ToString(), ""));
                    foreach (DataRow item1 in dsSub.Tables[0].Rows)
                    {
                        ddlCustomer.Items.Add("　|--"+new ListItem(item1["CompanyName"].ToString(), item1["Id"].ToString()));
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
                ddlPaper.Items.Add(new ListItem(item["NameInfo"].ToString()+ "(" + item["PaperSpec"].ToString()+")", item["Id"].ToString()));
            }

        }


        /// <summary>
        /// 绑定公版
        /// </summary>
        void BindPublicversion()
        {
            DataSet ds = bllPublicversion.GetList(0, "StateInfo=1", "SortNum desc,Id asc");

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                ddlPublicversion.Items.Add(new ListItem(item["NameInfo"].ToString(), item["Id"].ToString()));
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
                repSubTechnology.DataSource = bllTechnology.GetList(0, "StateInfo=1 and ParentId="+ds.Tables[0].Rows[i]["Id"].ToString(), "SortNum desc,Id asc");
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

        }
    }
}