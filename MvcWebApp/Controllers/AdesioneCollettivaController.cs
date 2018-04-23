using MvcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebApp.CustomCode;

namespace MvcWebApp.Controllers
{
    public class AdesioneCollettivaController : Controller
    {
        //
        // GET: /AdesioneCollettiva/

        public ActionResult Index()
        {
            List<string> enti = new List<string>();
            List<string> tipoSoggetti = new List<string>();
            List<string> tipoAdesioni = new List<string>();
            List<string> legami = new List<string>();

            using (HelperService _hp = new HelperService ())
            {
                enti = _hp.channel.GetAllEnti().Select(x=>x.CodiceEnte).ToList();
                tipoSoggetti = _hp.channel.GetTipoSoggetti().Select(x => x.DescTipoSoggetto).ToList();
                tipoAdesioni = _hp.channel.GetTipoAdesioni().Select(x => x.DescBreve).ToList();
                legami = _hp.channel.GetTipiLegame().Select(x => x.DescLegame).ToList();

            }

            #region DropDownList
            List<SelectListItem> entiList = new List<SelectListItem>();
            List<SelectListItem> soggettiList = new List<SelectListItem>();
            List<SelectListItem> tipoAdesioniList = new List<SelectListItem>();
            List<SelectListItem> tipoLegamiList = new List<SelectListItem>();

            foreach (string valore in enti)
            {
                SelectListItem elem = new SelectListItem { Text = valore, Value = valore };
                entiList.Add(elem);
            }

            foreach (string valore in tipoSoggetti)
            {
                SelectListItem elem = new SelectListItem { Text = valore, Value = valore };
                soggettiList.Add(elem);
            }

            foreach (string valore in tipoAdesioni)
            {
                SelectListItem elem = new SelectListItem { Text = valore, Value = valore };
                tipoAdesioniList.Add(elem);
            }

            foreach (string valore in legami)
            {
                SelectListItem elem = new SelectListItem { Text = valore, Value = valore };
                tipoLegamiList.Add(elem);
            } 
            #endregion

            SearchAdesioniModel modello = new SearchAdesioniModel();
            modello.ListItemTipoSoggetto = new SelectList(soggettiList, "Text", "Value", 0);
            modello.ListItemEnti = new SelectList (entiList, "Text", "Value", 0);
            modello.ListItemTipoAdesione = new SelectList(tipoAdesioniList, "Text", "Value", 0);
            modello.ListItemLegami = new SelectList(tipoLegamiList, "Text", "Value", 0);

            modello.Results = new List<AdesioneModel>();

            return View(modello);
        }

        public ActionResult RisultatiAdesioni(SearchAdesioniModel model) 
        {
            Session["Adesioni"] = model.Results;
            return PartialView();
        }

        public ActionResult LoadTable()
        {
            return Json(Session["Adesioni"], JsonRequestBehavior.AllowGet);
        }

        public ActionResult ModificaAdesione() 
        {
            AdesioneModel model = new AdesioneModel();
            return View(model);
        }

        public ActionResult CancellaAdesione() 
        {
            return View();
        }

        public ActionResult SalvaAdesione(AdesioneModel model) 
        {
            return View("ModificaAdesione");
        }

        public ActionResult CreaAdesione() 
        {
            return View();
        }

        public ActionResult AggiungiAdesione(AdesioneModel model) 
        {
            return View("Index");
        }
    }
}
