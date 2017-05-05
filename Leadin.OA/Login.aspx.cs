using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LitJson;
using System.Web.Services;

namespace Leadin.OA
{
    public partial class Login : System.Web.UI.Page
    {

        BLL.Workers bll = new BLL.Workers();

        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack)
            {
                //JsMessage("text", 2000);
            }
        }


        

        protected void btn_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(Request.Form["txtAccount"]) && !string.IsNullOrEmpty(Request.Form["txtPassword"]))
            {
                string account = Request.Form["txtAccount"];
                string pwd = Leadin.Common.DESEncrypt.Encrypt(Request.Form["txtPassword"]);

                List<Model.Workers> list = bll.GetModelList("Account='" + account + "' and Pwd='" + pwd + "'");

                if (Session["loginnum"] == null)
                {
                    Session["loginnum"] = 0;
                }

                if (list.Count > 0)
                {
                    if (string.Equals(list[0].StateInfo, 1))
                    {
                        Session["loginnum"] = null;
                        Session["AdminId"] = list[0].Id;
                        Session["AdminAccount"] = list[0].Account;
                        Session.Timeout = 45;
                        Leadin.Common.Utils.WriteCookie("AdminAccount", account);
                        Leadin.Common.Utils.WriteCookie("AdminPwd", pwd);
                        JsMessage("登录成功", 1500,"true");
                    }
                    else
                    {
                        JsMessage("您的帐号已被禁用，请联系管理人员", 1500); 
                    }
                }
                else
                {
                    Session["loginnum"] = (int.Parse(Session["loginnum"].ToString()) + 1).ToString();
                    JsMessage("用户名或密码输入不正确", 1500);
                }

            }
        }

        public void JsMessage(string text, int time)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "tooler", "$.tooltip(\"" + text + "\"," + time + ");", true);
        }

        public void JsMessage(string text, int time, string state )
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "tooler", "$.tooltip(\"" + text + "\"," + time + "," + state + ");", true);
        }
    }
}