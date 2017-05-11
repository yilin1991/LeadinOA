using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leadin.OA.Tools
{
    /// <summary>
    /// CheckPaperNumId 的摘要说明
    /// </summary>
    public class CheckPaperNumId : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.Paper bll = new BLL.Paper();

            string strAccount = context.Request["param"].ToString();


            JsonData data = new JsonData();


            if (bll.GetRecordCount("NumId='" + strAccount + "'") > 0)
            {
                data["status"] = "n";
                data["info"] = "纸张编号已存在！";
            }
            else
            {
                data["status"] = "y";
            }

            context.Response.Write(data.ToJson());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}