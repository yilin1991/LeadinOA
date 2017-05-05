using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadin.Web.UI
{
    public class ManagePage:System.Web.UI.Page
    {



        public void JsMessage(string text,int time,bool state=false)
        {
            string msbox = "";
            msbox += "<script type=\"text/javascript\">\n";
            msbox += "$.tooltip('"+text+"',"+time+","+state+")";
            msbox += "</script>\n";
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "tooltip", msbox);
        }
         //$.tooltip('错误提示文字'); 或者  $.tooltip('正确提示文字',4000,true, callback);  //内置2种提示风格(参数1为提示文字，参数2为自动关闭时间，参数3：true为正确，false为错误，参数4: 回调函数)

    }
}
