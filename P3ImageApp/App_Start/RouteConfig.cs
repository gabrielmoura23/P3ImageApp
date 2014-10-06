using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace P3ImageApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { controller = "Home|Campo|Formulario|Autenticacao|Categoria|Erro|Interno|SubCategoria" }
            );

            routes.MapRoute(
            name: "TesteSlug",
            url: "{slugcategoria}/{slugsubcategoria}",
            defaults: new { controller = "SubCategoria", action = "Dinamico", slugcategoria = "", slugsubcategoria = "" },
            constraints: new { controller = "SubCategoria", action = "Dinamico" }
            );

        }
    }
}