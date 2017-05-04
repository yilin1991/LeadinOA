using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LitJson;


namespace Leadin.OASystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public string Login(string account,string password)
        {

            JsonData jd = new JsonData();
            jd["account"] = account;
            jd["pwd"] = password;


          string loginMsg=  Leadin.Common.HttpHelper.Post(jd.ToJson(), "http://192.168.1.115:8022/api/Workers/Login");

           

            return loginMsg;
        }


    }
}