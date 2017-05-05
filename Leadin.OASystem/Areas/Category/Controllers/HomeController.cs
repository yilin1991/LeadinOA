using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LitJson;

namespace Leadin.OASystem.Areas.Category.Controllers
{
    public class HomeController : Controller
    {
        // GET: Category/Home
        public ActionResult Index()
        {
            string str = Leadin.Common.HttpHelper.Get("http://192.168.1.115:8022/api/category/GetCategoryList");


            List<Model.Category> list = JsonMapper.ToObject<List<Model.Category>>(str);


            return View(list);
        }



        public ActionResult Add()
        {


            string str = Leadin.Common.HttpHelper.Get("http://192.168.1.115:8022/api/category/GetCategoryList");


            List<Model.Category> list = JsonMapper.ToObject<List<Model.Category>>(str);


            return View();
        }

    }
}