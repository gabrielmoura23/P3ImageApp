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
            name: "TesteSlug1",
            url: "teste/{slugcategoria}",
            defaults: new { controller = "Formulario", action = "Categoria", slugcategoria = "" }
            );

            routes.MapRoute(
            name: "TesteSlug2",
            url: "teste/{slugcategoria}/{slugsubcategoria}",
            defaults: new { controller = "Formulario", action = "SubCategoria", slugcategoria = "", slugsubcategoria = "" }
            );

            routes.MapRoute(
            name: "TesteSlug3",
            url: "teste/{slugcategoria}/{slugsubcategoria}/{desccampo}",
            defaults: new { controller = "Formulario", action = "Campo", slugcategoria = "", slugsubcategoria = "", desccampo = "" }
            );

            routes.MapRoute(
            name: "TesteSlug21",
            url: "teste1/{slugcategoria}/{slugsubcategoria}",
            defaults: new { controller = "SubCategoria", action = "Dinamico", slugcategoria = "", slugsubcategoria = "" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            
        }
    }
}