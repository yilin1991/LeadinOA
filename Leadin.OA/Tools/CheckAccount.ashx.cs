using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leadin.OA.Tools
{
    /// <summary>
    /// CheckAccount 的摘要说明
    /// </summary>
    public class CheckAccount : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            BLL.Workers bll = new BLL.Workers();

            string strAccount = context.Request["param"].ToString();


            JsonData data = new JsonData();


            if (bll.GetRecordCount("Account='" + strAccount + "'") > 0)
            {
                data["status"] = "n";
                data["info"] = "该帐号已存在请重新输入！";
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