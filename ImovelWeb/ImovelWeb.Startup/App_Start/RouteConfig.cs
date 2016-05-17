using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ImovelWeb.Startup
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // passagem de parametro na url 
            routes.MapRoute("Home", "codigo/{codigoimovel_}", new { controller = "Home", action = "Comprarmoveis", codigoimovel_ = UrlParameter.Optional });

            
        }
    }
}
