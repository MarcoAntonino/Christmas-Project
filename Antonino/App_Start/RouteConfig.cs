using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Antonino
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Save",
              url: "products/save/{name}/{id}",
              defaults: new
              {
                  controller = "Products",
                  action = "Save",
                  id = UrlParameter.Optional
              }
              );

            routes.MapRoute(
                name: "ByName",
                url: "products/{action}/{name}",
                defaults: new { controller = "Products" }
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
