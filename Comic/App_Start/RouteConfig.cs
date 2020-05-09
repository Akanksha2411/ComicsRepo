using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Comic
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");            

            routes.MapRoute(
                name: "Comics",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Comics", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Create",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Comics", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
