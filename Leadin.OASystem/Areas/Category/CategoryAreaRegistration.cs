using System.Web.Mvc;

namespace Leadin.OASystem.Areas.Category
{
    public class CategoryAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Category";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Category_default",
                "Category/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "Leadin.OASystem.Areas.Category.Controllers" }
            );
        }
    }
}