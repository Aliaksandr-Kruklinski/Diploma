using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SocialNetwork.WebUI
{
    public static class MapRoutes
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            RegisterAccountRoutes(routes);
            RegisterVerifyRoutes(routes);

            RegisterMenuRoutes(routes);
            RegisterProductRoutes(routes);
        }

        private static void RegisterAccountRoutes(RouteCollection routes)
        {
            routes.MapRoute(null, "SignUp", new { controller = "Account", action = "SignUp" });
            routes.MapRoute(null, "Account/SignUp", new { controller = "Account", action = "SignUp" });
            routes.MapRoute(null, "Registration", new { controller = "Account", action = "SignUp" });
            routes.MapRoute(null, "Register", new { controller = "Account", action = "SignUp" });
            routes.MapRoute(null, "LogIn", new { controller = "Account", action = "LogIn" });
            routes.MapRoute(null, "Account/LogOn", new { controller = "Account", action = "LogIn" });
            routes.MapRoute(null, "LogOn", new { controller = "Account", action = "LogIn" });
        }

        private static void RegisterVerifyRoutes(RouteCollection routes)
        {
            routes.MapRoute(null, "Verify/{Email}", new { controller = "Verify", action = "Index" });
            routes.MapRoute(null, "Verify/Verify/{Email}/{SecretCode}", new { controller = "Verify", action = "Verify" });
        }

        private static void RegisterMenuRoutes(RouteCollection routes)
        {
            routes.MapRoute(null, "{selectedLink}", new { controller = "Menu", action = "Menu"});
        }

        private static void RegisterProductRoutes(RouteCollection routes)
        {
            routes.MapRoute(null, "Page{page}", new { controller = "Product", action = "List", category = (string)null }, new { page = @"\d+" });
            routes.MapRoute(null, "{category}", new { controller = "Product", action = "List", page = 1 });
            routes.MapRoute(null, "{category}/Page{page}", new { controller = "Product", action = "List" }, new { page = @"\d+" });
        }
    }
}