using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "AdicionarCidade", // Route name
                "cidade/add", // URL with parameters
                new { controller = "Cidade", action = "Add", id = UrlParameter.Optional } // Parameter defaults
                );

            routes.MapRoute(
                "AtualizarCidade", // Route name
                "cidade/{codigo}", // URL with parameters
                new { controller = "Cidade", action = "Update", id = UrlParameter.Optional } // Parameter defaults
                );

            routes.MapRoute(
                "ExcluirCidade", // Route name
                "cidade/{codigo}", // URL with parameters
                new { controller = "Cidade", action = "Delete", id = UrlParameter.Optional } // Parameter defaults
                );

            routes.MapRoute(
                "ConsultarCidade", // Route name
                "cidade/select/{codigo}", // URL with parameters
                new { controller = "Cidade", action = "Select", id = UrlParameter.Optional } // Parameter defaults
                );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}