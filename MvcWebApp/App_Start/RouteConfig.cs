using System;
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
                url: "{controller}/{action}/{en}/{page}/{tt}", 
                defaults: new { controller = "GestioneAnagrafica", action = "InLavorazione", en = UrlParameter.Optional, page=UrlParameter.Optional, tt=UrlParameter.Optional }
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
            routes.MapRoute(
               name: "EditSoggetto",
               url: "{GestioneAnagrafica}/{EditSoggettoImportato}/{id}/{page}",
               defaults: new { controller = "GestioneAnagrafica", action = "EditSoggettoImportato", id =UrlParameter.Optional, page = ""}
           );
            routes.MapRoute(
              name: "Modifica",
              url: "{GestioneAnagrafica}/{ModificaAdesione}/{id}",
              defaults: new { controller = "AdesioneCollettiva", action = "ModificaAdesione", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Scarta",
              url: "{GestioneAnagrafica}/{CancellaAdesione}/{id}",
              defaults: new { controller = "AdesioneCollettiva", action = "CancellaAdesione", id = UrlParameter.Optional }
          );
            routes.MapRoute(
             name: "Invia",
             url: "{GestioneAnagrafica}/{SalvaAdesione}/{cf}/{page}",
             defaults: new { controller = "AdesioneCollettiva", action = "SalvaAdesione", id = UrlParameter.Optional, page = UrlParameter.Optional }
         );
        }
    }
}