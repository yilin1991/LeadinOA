using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LitJson;
namespace Leadin.WebAPI.Controllers
{
    public class WorkersController : ApiController
    {

        BLL.Workers bll = new BLL.Workers();

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

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }


        [HttpPost]
        public HttpResponseMessage Login(string account,string pwd)
        {
            JsonData jd = new JsonData();

            List<Model.Workers> model = bll.GetModelList("Account='"+account+ "' and Pwd='"+ Common.DESEncrypt.Encrypt(pwd)+"'");

            if (model.Count > 0)
            {
                jd["code"] = 200;
                jd["account"] = model[0].Account;
                jd["Id"] = model[0].Id;
                jd["NumId"] = model[0].NumId;
                jd["msg"] = "登录成功";
            }
            else
            {
                jd["code"] = 400;
                jd["msg"] = "用户名或密码输入不正确，请重新输入";
            }


            HttpResponseMessage request = new HttpResponseMessage { Content = new StringContent(jd.ToJson()) };

            return request;
        }
        


    }
}