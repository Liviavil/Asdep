﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcWebApp
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
            routes.MapRoute(
                name: "LavoraEnte",
                url: "{controller}/{action}/{enteQuerystring}",
                defaults: new { controller = "GestioneAnagrafica", action = "InLavorazione", enteQuerystring = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SoggettiByEnte",
                url: "{controller}/{action}/{modello}",
                defaults: new { controller = "GestioneAnagrafica", action = "InLavorazione", modello = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SoggettiImportati",
                url: "{controller}/{action}/{results}",
                defaults: new { controller = "GestioneAnagrafica", action = "SoggettiImportati", modello = UrlParameter.Optional }
            );
        }
    }
}