using MvcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebApp.CustomCode;
using Asdep.Common.DAO;
using Newtonsoft.Json;

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

            using (HelperService _hp = new HelperService())
            {
                enti = _hp.channel.GetAllEnti().Select(x => x.CodiceEnte).ToList();
                tipoSoggetti = _hp.channel.GetTipoSoggetti().Select(x => x.DescTipoSoggetto).ToList();
                tipoAdesioni = _hp.channel.GetTipoAdesioni().Select(x => x.DescBreve).ToList();
                legami = _hp.channel.GetTipiLegame().Select(x => x.DescLegame).ToList();

            }

            #region DropDownList
            List<SelectListItem> entiList = new List<SelectListItem>();
            List<SelectListItem> soggettiList = new List<SelectListItem>();
            List<SelectListItem> tipoAdesioniList = new List<SelectListItem>();
            List<SelectListItem> tipoLegamiList = new List<SelectListItem>();

            SelectListItem elem1 = new SelectListItem { Value = "", Text = "0" };
            entiList.Add(elem1);
            soggettiList.Add(elem1);
            tipoAdesioniList.Add(elem1);
            tipoLegamiList.Add(elem1);

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
            modello.ListItemEnti = new SelectList(entiList, "Text", "Value", 0);
            modello.ListItemTipoAdesione = new SelectList(tipoAdesioniList, "Text", "Value", 0);
            modello.ListItemLegami = new SelectList(tipoLegamiList, "Text", "Value", 0);

            modello.Results = new List<Asdep.Common.DAO.AdesioneDao>();


            return View(modello);
        }

        [HttpPost]
        public ActionResult RisultatiAdesioni(SearchAdesioniModel model)
        {
            string nome = model.Nome;
            string cognome = model.Cognome;
            string ente = model.selectedEnte;
            string legame = model.selectedLegami;
            string adesione = model.selectedTipoAdesione;
            string tiposoggetto = model.selectedTipoSoggetto;

            List<Asdep.Common.DAO.AdesioneDao> adesioni = new List<Asdep.Common.DAO.AdesioneDao>();

            using (HelperService _hp = new HelperService())
            {
                adesioni = _hp.channel.RicercaAdesioni();
            }

            if (!string.IsNullOrEmpty(nome))
                adesioni = adesioni.Where(x => x.Soggetto.Nome.Equals(nome)).ToList();
            if (!string.IsNullOrEmpty(cognome))
                adesioni = adesioni.Where(x => x.Soggetto.Cognome.Equals(cognome)).ToList();
            if (!ente.Equals("0"))
                adesioni = adesioni.Where(x => x.Ente.CodiceEnte.Equals(ente)).ToList();
            if (!legame.Equals("0"))
                adesioni = adesioni.Where(x => x.T_TipiLegame.DescLegame.Equals(legame)).ToList();
            if (!adesione.Equals("0"))
                adesioni = adesioni.Where(x => x.T_TipoAdesione.DescBreve.Equals(adesione)).ToList();
            if (!tiposoggetto.Equals("0"))
                adesioni = adesioni.Where(x => x.T_TipoSoggetto.DescTipoSoggetto.Equals(tiposoggetto)).ToList();


            Session["Adesioni"] = adesioni;
            model.Results = adesioni;

            return PartialView(adesioni);
        }

        public ActionResult LoadTable()
        {
            List<Asdep.Common.DAO.AdesioneDao> adesioni = Session["Adesioni"] as List<Asdep.Common.DAO.AdesioneDao>;
            //string json = JsonConvert.SerializeObject(adesioni);
            return Json(adesioni, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ModificaAdesione(long id)
        {
            Asdep.Common.DAO.AdesioneDao model = new Asdep.Common.DAO.AdesioneDao();

            //List per le drop down
            List<EnteDao> enti = new List<EnteDao>();
            List<T_TipiLegameDao> legami = new List<T_TipiLegameDao>();
            List<T_TipoSoggettoDao> tipiSogg = new List<T_TipoSoggettoDao>();
            List<T_TipoAdesioneDao> tipoAdesione = new List<T_TipoAdesioneDao>();

            using (HelperService _hp = new HelperService())
            {
                enti = _hp.channel.GetAllEnti();
                legami = _hp.channel.GetTipiLegame();
                tipiSogg = _hp.channel.GetTipoSoggetti();
                tipoAdesione = _hp.channel.GetTipoAdesioni().Where(x => x.CategoriaAdesione.Equals("AC")).ToList(); ;
                model = _hp.channel.GetAdesioneById(id);
            }

            #region DropDownList
            List<SelectListItem> entiList = new List<SelectListItem>();
            List<SelectListItem> soggettiList = new List<SelectListItem>();
            List<SelectListItem> tipoAdesioniList = new List<SelectListItem>();
            List<SelectListItem> tipoLegamiList = new List<SelectListItem>();

            foreach (EnteDao valore in enti)
            {
                SelectListItem elem = new SelectListItem { Text = valore.CodiceEnte, Value = valore.IdEnte.ToString() };
                entiList.Add(elem);
            }

            foreach (T_TipoSoggettoDao valore in tipiSogg)
            {
                SelectListItem elem = new SelectListItem { Text = valore.DescTipoSoggetto, Value = valore.CodTipoSoggetto };
                soggettiList.Add(elem);
            }

            foreach (T_TipoAdesioneDao valore in tipoAdesione)
            {
                SelectListItem elem = new SelectListItem { Text = valore.DescBreve, Value = valore.CodTipoAdesione };
                tipoAdesioniList.Add(elem);
            }

            foreach (T_TipiLegameDao valore in legami)
            {
                SelectListItem elem = new SelectListItem { Text = valore.DescLegame, Value = valore.CodLegame };
                tipoLegamiList.Add(elem);
            }

            Session["EntiList"] = entiList;
            Session["TipiSoggList"] = soggettiList;
            Session["TipiLegamiList"] = tipoLegamiList;
            Session["TipiAdesList"] = tipoAdesioniList;
            ViewBag.EntiList = entiList;
            ViewBag.TipiSoggList = soggettiList;
            ViewBag.TipiLegamiList = tipoLegamiList;
            ViewBag.TipiAdesList = tipoAdesioniList;
            #endregion

            return View(model);
        }

        public ActionResult CancellaAdesione(long id)
        {
            Asdep.Common.DAO.AdesioneDao model = new Asdep.Common.DAO.AdesioneDao();
            using (HelperService _hp = new HelperService())
            {
                AdesioneDao adesione = _hp.channel.GetAdesioneById(id);
                _hp.channel.CessazioneAdesione(adesione);
            }
            return View();
        }

        public ActionResult SalvaAdesione(Asdep.Common.DAO.AdesioneDao model)
        {
            AdesioneDao _dao = new AdesioneDao();
            ViewBag.EntiList = Session["EntiList"];
            ViewBag.TipiSoggList = Session["TipiSoggList"];
            ViewBag.TipiLegamiList = Session["TipiLegamiList"];
            ViewBag.TipiAdesList = Session["TipiAdesList"];

            using (HelperService _hp = new HelperService())
            {
                _dao = _hp.channel.ModificaAdesione(model.IdAdesione);
            }

            if (_dao.ErroriList.Any())
            {
                return View("ModificaAdesione", _dao);
            }
            else
            {
                return View("Index");
            }
            //return Json(new { success = false, responseText = "The attached file is not supported." });
        }

        public ActionResult CreaAdesione()
        {
            #region DropDownList
            List<EnteDao> enti = new List<EnteDao>();
            List<T_TipiLegameDao> legami = new List<T_TipiLegameDao>();
            List<T_TipoSoggettoDao> tipiSogg = new List<T_TipoSoggettoDao>();
            List<T_TipoAdesioneDao> tipoAdesione = new List<T_TipoAdesioneDao>();
            using (HelperService _hp = new HelperService())
            {
                enti = _hp.channel.GetAllEnti();
                legami = _hp.channel.GetTipiLegame();
                tipiSogg = _hp.channel.GetTipoSoggetti();
                tipoAdesione = _hp.channel.GetTipoAdesioni();
            }


            List<SelectListItem> entiList = new List<SelectListItem>();
            List<SelectListItem> soggettiList = new List<SelectListItem>();
            List<SelectListItem> tipoAdesioniList = new List<SelectListItem>();
            List<SelectListItem> tipoLegamiList = new List<SelectListItem>();

            foreach (EnteDao valore in enti)
            {
                SelectListItem elem = new SelectListItem { Text = valore.CodiceEnte, Value = valore.IdEnte.ToString() };
                entiList.Add(elem);
            }

            foreach (T_TipoSoggettoDao valore in tipiSogg)
            {
                SelectListItem elem = new SelectListItem { Text = valore.DescTipoSoggetto, Value = valore.CodTipoSoggetto };
                soggettiList.Add(elem);
            }

            foreach (T_TipoAdesioneDao valore in tipoAdesione)
            {
                SelectListItem elem = new SelectListItem { Text = valore.DescBreve, Value = valore.CodTipoAdesione };
                tipoAdesioniList.Add(elem);
            }

            foreach (T_TipiLegameDao valore in legami)
            {
                SelectListItem elem = new SelectListItem { Text = valore.DescLegame, Value = valore.CodLegame };
                tipoLegamiList.Add(elem);
            }

            Session["EntiList"] = entiList;
            Session["TipiSoggList"] = soggettiList;
            Session["TipiLegamiList"] = tipoLegamiList;
            Session["TipiAdesList"] = tipoAdesioniList;
            ViewBag.EntiList = entiList;
            ViewBag.TipiSoggList = soggettiList;
            ViewBag.TipiLegamiList = tipoLegamiList;
            ViewBag.TipiAdesList = tipoAdesioniList;
            #endregion

            AdesioneDao dao = new AdesioneDao();
            dao.Soggetto = new SoggettoDao();
            dao.Soggetto1 = new SoggettoDao();
            dao.ErroriList = new List<T_ErroriIODao>();
            return View(dao);
        }

        public ActionResult AggiungiAdesione(AdesioneDao model)
        {
            try
            {
                ViewBag.EntiList = Session["EntiList"];
                ViewBag.TipiSoggList = Session["TipiSoggList"];
                ViewBag.TipiLegamiList = Session["TipiLegamiList"];
                ViewBag.TipiAdesList = Session["TipiAdesList"];

                List<T_ErroriIODao> errori = new List<T_ErroriIODao>();

                int result = -1;
                model.ErroriList = errori;
                using (HelperService _hp = new HelperService())
                {
                    errori = _hp.channel.VerificaAdesione(model);
                }
                model.ErroriList = errori;
                if (model.ErroriList.Any())
                {
                    return View("CreaAdesione", model);
                }
                else
                {
                    using (HelperService _hp = new HelperService())
                    {
                        result = _hp.channel.AggiungiAdesione(model);
                    }
                }
                if (result > 0) return View("CreaAdesione", model);
                else
                {
                    ViewBag.Errore = "Contattare l'amministratore";
                    return View("CreaAdesione", model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Errore = ex.Message;
                return View("CreaAdesione", model);
            }

        }
    }
}
