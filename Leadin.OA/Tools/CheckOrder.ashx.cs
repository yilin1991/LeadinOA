using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leadin.OA.Tools
{
    /// <summary>
    /// CheckOrder 的摘要说明
    /// </summary>
    public class CheckOrder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            BLL.FatherOrder bll = new BLL.FatherOrder();

            string customerId = context.Request["param"].ToString();


            JsonData data = new JsonData();


            if (bll.GetRecordCount("CustomerId=" + customerId + " and AddTime>Convert(datetime,'" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00" + "') and Convert(datetime,AddTime) <= Convert(datetime,'" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59" + "')") > 0)
            {
                data["status"] = "n";
                data["info"] = "该公司今天已下单，请勿重复下单！";
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