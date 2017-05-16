using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using LitJson;

namespace Leadin.OA.Tools
{
    /// <summary>
    /// GetDelivery 的摘要说明
    /// </summary>
    public class GetDelivery : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            JsonData jd = new JsonData();
            StringBuilder strDelivery = new StringBuilder();

            string did = context.Request["did"].ToString();

            

            if (string.Equals(did, "10018"))//公司配送
            {
                strDelivery.Append("<option value=''>请选择配送人员</option>");
                BLL.Workers bll = new BLL.Workers();
                DataSet ds = bll.GetList("StateInfo=1 and TypeId=10018");
               
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    strDelivery.Append("<option value='"+item["Id"].ToString()+"'>"+item["NameInfo"].ToString() +"</option>");
                }

            }
            if (string.Equals(did, "10019"))//快递配送
            {
                strDelivery.Append("<option value=''>请选择快递公司</option>");
                BLL.Distribution bll = new BLL.Distribution();
                DataSet ds = bll.GetList("StateInfo=1");

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    strDelivery.Append("<option value='" + item["Id"].ToString() + "'>" + item["CompanyName"].ToString() + "</option>");
                }
            }

            jd["Id"] = 1;
            jd["strDelivery"] = strDelivery.ToString();

            context.Response.Write(jd.ToJson());
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