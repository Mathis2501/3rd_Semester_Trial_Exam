using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace _03_WebApi_praticeExam_01
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
                routeTemplate: "api/{controller}/{itemNumber}",
                defaults: new { itemNumber = RouteParameter.Optional }
            );
        }
    }
}
