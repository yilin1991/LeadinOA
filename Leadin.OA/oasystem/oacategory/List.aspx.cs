using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.OA.oasystem.oacategory
{
    public partial class List : System.Web.UI.Page
    {


        BLL.Category bll = new BLL.Category();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepCategoryList();
            }
        }


        void BindRepCategoryList()
        {

            repCategoryList.DataSource = bll.GetList("ParentId=0");
            repCategoryList.DataBind();



            for (int i = 0; i < repCategoryList.Items.Count; i++)
            {
                HiddenField hidId = repCategoryList.Items[i].FindControl("hidId") as HiddenField;

                Repeater repSecondList = repCategoryList.Items[i].FindControl("repSecondList") as Repeater;


                repSecondList.DataSource= bll.GetList("ParentId="+hidId.Value);
                repSecondList.DataBind();


            }


        }


    }
}