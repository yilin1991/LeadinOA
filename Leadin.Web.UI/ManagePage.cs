using Leadin.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leadin.Web.UI
{
    public class ManagePage : System.Web.UI.Page
    {

        public ManagePage()
        {
            this.Load += new EventHandler(ManagePage_Load);

        }

        void ManagePage_Load(object sender, EventArgs e)
        {
            if (!CheckLogin())
            {
                Response.Write("<script>parent.location.href='/login.aspx'</script>");
                Response.End();
            }
        }

        /// <summary>
        /// 判断管理员是否已经登录(解决Session超时问题)
        /// </summary>
        /// <summary>
        /// 检查是否登录
        /// </summary>
        /// <returns></returns>
        public bool CheckLogin()
        {



            if (Session["AdminId"] != null && Session["AdminAccount"] != null)
            {
                return true;
            }
            else
            {
                BLL.Workers bll = new BLL.Workers();
                if (!string.IsNullOrWhiteSpace(Utils.GetCookie("AdminAccount")) && !string.IsNullOrWhiteSpace(Utils.GetCookie("AdminPwd")))
                {
                    string adminName = Utils.GetCookie("AdminAccount");
                    string adminPass = Utils.GetCookie("AdminPwd");

                    DataSet ds = bll.GetList("Account='" + adminName + "' and Pwd='" + adminPass + "'");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["AdminId"] = ds.Tables[0].Rows[0]["Id"].ToString();
                        Session["AdminAccount"] = ds.Tables[0].Rows[0]["Account"].ToString();
                        return true;
                    }
                }

            }

            return false;
        }

        /// <summary>
        /// 绑定下拉列表类别
        /// </summary>
        public void BindddlType(int PID, DropDownList ddl, bool state = false)
        {

            BLL.Category bll = new BLL.Category();
            Model.Category model = new Model.Category();

            int typelevel = 0;

            if (PID != 0)
            {
                model = bll.GetModel(PID);
                typelevel = model.LevelNum + 1;
            }


            DataTable dt = bll.GetListChild(PID, state);
            foreach (DataRow item in dt.Rows)
            {
                string value = item["Id"].ToString();
                int levelNum = int.Parse(item["LevelNum"].ToString()) - typelevel;
                string title = item["Title"].ToString();

                if (levelNum > 0)
                {
                    title = "|--" + title;
                    title = Utils.StringOfChar(levelNum, "　") + title;
                }

                ddl.Items.Add(new ListItem(title, value));
            }

        }





        /// <summary>
        /// 提示窗口
        /// </summary>
        /// <param name="text">提示信息</param>
        /// <param name="time">关闭时间</param>
        /// <param name="state">提示状态true成功，false失败，默认flase</param>
        public void JsMessage(string text, int time, string state)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "tooler", "$.tooltip(\"" + text + "\"," + time + "," + state + ");", true);
        }

        /// <summary>
        /// 提示窗口
        /// </summary>
        /// <param name="text">提示信息</param>
        /// <param name="time">关闭时间</param>
        /// <param name="state">提示状态true成功，false失败，默认flase</param>
        /// <param name="backurl">弹窗关闭后跳转页面</param>
        public void JsMessage(string text, int time, string state, string backurl)
        {
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "tooler", "$.tooltip(\"" + text + "\"," + time + "," + state + ",function(){location.href='" + backurl + "'; });", true);
        }


        /// <summary>
        /// 获取类别名称
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public string GetCategoryName(int cid)
        {
            string cName = "";
            if (cid == 0)
            {
                cName = "顶级类别";
            }
            else
            {
                BLL.Category bll = new BLL.Category();
                cName = bll.GetModel(cid).Title;
            }

            return cName;
        }



        /// <summary>
        /// 获取子订单费用
        /// </summary>
        /// <param name="sonId"></param>
        /// <returns></returns>
        public decimal GetSonOrderMoney(int sonId)
        {
            BLL.SonOrder bllSonorder = new BLL.SonOrder();
            BLL.Paper bllPaper = new BLL.Paper();
            BLL.OrdeTechnology bllTechnology = new BLL.OrdeTechnology();


            decimal money = 0;

            Model.SonOrder modelOrder = bllSonorder.GetModel(sonId);

            Model.Paper modelPaper = bllPaper.GetModel(int.Parse(modelOrder.PaperId.ToString()));

            DataSet ds = bllTechnology.GetList("SonOrderId=" + sonId);


            foreach (DataRow item in ds.Tables[0].Rows)
            {
                money += decimal.Parse(item["Price"].ToString());
            }

            money += modelOrder.DifferencePrice;
            money += modelPaper.Price;
            return money;

        }


        /// <summary>
        /// 获取公司订单总金额
        /// </summary>
        /// <param name="fathrtId"></param>
        /// <returns></returns>
        public decimal GetFathrtMoney(int fathrtId)
        {


            decimal money = 0;

            BLL.OrdeDistribution bllDistrbution = new BLL.OrdeDistribution();
            BLL.SonOrder bllSonOrder = new BLL.SonOrder();

            DataSet dsDistubution = bllDistrbution.GetList("OrderId=" + fathrtId);
            DataSet dsSonOrder = bllSonOrder.GetList("FatherOrderId=" + fathrtId);

            if (dsSonOrder.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow item in dsSonOrder.Tables[0].Rows)
                {

                    money += GetSonOrderMoney(int.Parse(item["Id"].ToString()));

                }

                if (dsDistubution.Tables[0].Rows.Count > 0)
                {
                    money += decimal.Parse(dsDistubution.Tables[0].Rows[0]["Price"].ToString());
                }
            }

            return money;
        }




    }
}
