using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LitJson;
using System.Globalization;

namespace Leadin.OA.Tools
{
    /// <summary>
    /// GetCateGoryTree 的摘要说明
    /// </summary>
    public class GetCateGoryTree : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Leadin.BLL.Category bll = new BLL.Category();
            context.Response.ContentType = "text/plain";

            List<Model.Category> modelList = bll.GetModelList("");


            var result = modelList.Select(m => new
            {
                id = m.Id,
                pId = m.ParentId,
                name = m.Title,
                open = false,
                target = "DeployBase",
                url = "/oasystem/oacategory/detail.aspx?dptid=" + m.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();

            context.Response.Write(JsonMapper.ToJson(result));
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