using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Leadin.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var allowOrigins = ConfigurationManager.AppSettings["cors_allowOrigins"];
            var allowHeaders = ConfigurationManager.AppSettings["cors_allowHeaders"];
            var allowMethods = ConfigurationManager.AppSettings["cors_allowMethods"];
            var globalCors = new EnableCorsAttribute(allowOrigins, allowHeaders, allowMethods);
            config.EnableCors(globalCors);
            
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //这是重点，从配置文件的appsettings节点中读取跨域的地址
            
        }
    }
}
