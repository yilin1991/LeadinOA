using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Leadin.Model;
using Leadin.BLL;
using LitJson;
namespace Leadin.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        BLL.Category bll = new BLL.Category();


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

        
        public HttpResponseMessage GetCategoryList()
        {
            //JsonData jd = new JsonData(bll.GetModelList(""));

            string tojson = JsonMapper.ToJson(bll.GetModelList(""));

            return new HttpResponseMessage { Content = new StringContent(tojson) };

        }


        // POST api/<controller>
        public HttpResponseMessage Post([FromBody]Model.Category category)
        {
            JsonData jd = new JsonData();


            //BLL.Category bll = new BLL.Category();

            //jd["Category"] = bll.Add(category);
            jd["Success"] = "Success";
            jd["code"] = 400;

            HttpResponseMessage request = new HttpResponseMessage { Content = new StringContent(jd.ToJson()) };

            return request;

        }





        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}