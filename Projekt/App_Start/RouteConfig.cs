using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Projekt
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Front Controller
            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Front", action = "Index" }
            );

            routes.MapRoute(
                name: "Index",
                url: "Index",
                defaults: new { controller = "Front", action = "Index" }
            );

            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "Front", action = "About" }
            );

            routes.MapRoute(
                name: "Register",
                url: "Register",
                defaults: new { controller = "Front", action = "Register" }
            );

            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Front", action = "Login" }
            );

            routes.MapRoute(
                name: "Logout",
                url: "Logout",
                defaults: new { controller = "Front", action = "Logout" }
            );

            //List Controller
            routes.MapRoute(
                name: "List",
                url: "List",
                defaults: new { controller = "List", action = "List" }
            );

            routes.MapRoute(
                name: "Create",
                url: "Create",
                defaults: new { controller = "List", action = "Create" }
            );

            routes.MapRoute(
                name: "Edit",
                url: "Edit/{id}",
                defaults: new { controller = "List", action = "Edit", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Details",
                url: "Details/{id}",
                defaults: new { controller = "List", action = "Details" , id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Delete",
                url: "Delete/{id}",
                defaults: new { controller = "List", action = "Delete", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Forbidden",
                url: "Forbidden",
                defaults: new { controller = "List", action = "Forbidden" }
            );
        }
    }
}
