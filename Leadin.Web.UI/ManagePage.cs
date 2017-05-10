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
    public class ManagePage:System.Web.UI.Page
    {



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





    }
}
