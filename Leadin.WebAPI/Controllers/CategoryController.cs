using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Leadin.Model;
using Leadin.BLL;
using LitJson;
using System.Web.Http.Cors;

namespace Leadin.WebAPI.Controllers
{

    public class CategoryController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public HttpResponseMessage AddCategory([FromBody]categorys value)
        {
            JsonData jd = new JsonData();

            BLL.Category bll = new BLL.Category();
            jd["Success"] = "Success";
            jd["code"] = 400;

            HttpResponseMessage request = new HttpResponseMessage { Content = new StringContent(jd.ToJson()) };

            return request;

        }

        public void Put(int id, [FromBody]string value)
        {

        }

        public void Delete(int id)
        {
        }
    }

    public class categorys
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}