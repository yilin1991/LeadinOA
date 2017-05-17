using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
using System.Data;
using System.Text;

namespace Leadin.OA.Tools
{
    /// <summary>
    /// GetAddress 的摘要说明
    /// </summary>
    public class GetAddress : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            BLL.CustomerAddress blladdreess = new BLL.CustomerAddress();
            BLL.Customer bllCustomer = new BLL.Customer();
            BLL.PublicVersion bllVersion = new BLL.PublicVersion();

            JsonData jd = new JsonData();
            StringBuilder strAddress = new StringBuilder();
            StringBuilder strVersion = new StringBuilder();

            context.Response.ContentType = "text/plain";

            string customerId = context.Request["cid"];
            DataSet dsAddress = new DataSet();
            Model.Customer model = bllCustomer.GetModel(int.Parse(customerId));
            if (model.ParentId == 0)
            {
                dsAddress = blladdreess.GetList("StateInfo=1 and CustimerId=" + model.Id);
            }
            else
            {
                dsAddress = blladdreess.GetList("StateInfo=1 and CustimerId=" + model.ParentId);
            }
            strAddress.Append("<option value=''>请选择收货地址</option>");

            foreach (DataRow item in dsAddress.Tables[0].Rows)
            {
                strAddress.Append("<option value='"+item["Id"].ToString()+"'>"+item["NameInfo"].ToString()+", "+item["Addressinfo"].ToString()+", "+item["Phone"].ToString() +"</option>");
            }

            jd["stateInfo"] = 1;
            jd["strAddress"] = strAddress.ToString();


            DataSet dsVersion = bllVersion.GetList("StateInfo=1 and CustomerId=" + customerId);

            strVersion.Append("<option value=''>请选择客户公版</option>");
            foreach (DataRow item in dsVersion.Tables[0].Rows)
            {
                strVersion.Append("<option value='" + item["Id"].ToString() + "'>" + item["NameInfo"].ToString()+ "</option>");
            }

            jd["strVersion"] = strVersion.ToString();



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