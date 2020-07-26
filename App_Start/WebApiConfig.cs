using AppGlovo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AppGlovo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.MessageHandlers.Add(new TokenValidationHandler());
            // Web API routes
            config.MapHttpAttributeRoutes();

            //var cors = new EnableCorsAttribute("", "*", "*");
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
