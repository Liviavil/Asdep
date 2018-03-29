using AsdepGestioneAnagraficheBLL;
using AsdepGestioneAnagraficheBLL.Model;
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

            IServiceAsdep<AssicuratiBL> inter = new AssicuratiService();
            List<AssicuratiBL> list =  inter.GetAll();

            //AssicuratiBL assicurato = new AssicuratiBL
            //{
            //    IdAssicurato = "xxx",
            //    Cognome = "xxx",
            //    Nome = "xxx",
            //    CodiceFiscaleAssicurato = "xxx",
            //    CodiceFiscaleCapoNucleo = "xxx",
            //    CodiceLegame = "1",
            //    DataEffetto = DateTime.Now,
            //    DataInserimento = DateTime.Now,
            //    DataUltimoAggiornamento = DateTime.Now,
            //    Convenzione = "xxx",
            //    Categoria = "xxx",
            //    NumeroPolizza = "xxx",
            //    DataCessazione = DateTime.Now,
            //    CodiceEnte="1",
            //    Matricola="xxx",
            //    LuogoNascitaAssicurato="xxx",
            //    Progressivo="xxx"
            //};

            //bool aggiunto = inter.AddAssicuratoBL(assicurato);
            //Helper hp = new Helper();
            //hp.InitializeWorkbook(@"Book1.xls");
            //hp.ConvertToDataTable();

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
    }
}
