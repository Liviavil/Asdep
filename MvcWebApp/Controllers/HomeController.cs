using Asdep.Common.DAO;
using MvcWebApp.CustomCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";


           

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SoggettiImportatiAppoggio() 
        {
            List<SoggettiImportAppoggioDao> soggs = new List<SoggettiImportAppoggioDao>();
            using (HelperService help = new HelperService())
            {
                soggs = help.channel.GetSoggettiByEnte("INAIL");
            }
            return View(soggs);
        }

        public ActionResult SoggettiImportatiAppoggioEdit(int id)
        { return View(); }
    }
}
