using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TalentManager.Handlers;

namespace TalentManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //// Add global authorize attribute
            //config.Filters.Add(new AuthorizeAttribute());

            config.MessageHandlers.Add(new MyHandler());
        }
    }
}
