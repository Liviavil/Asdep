using MvcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebApp.CustomCode;
using System.ServiceModel.Web;
using WcfService;
using System.IO;
using Asdep.Common.DAO;
using System.Data;

namespace MvcWebApp.Controllers
{
    public class GestioneAnagraficaController : Controller
    {
        public ActionResult Carica(HttpPostedFileBase file)
        {
            string ente = "INAIL";
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string path = //Path.Combine(Server.MapPath("~/"),
                                               Path.GetFileName(file.FileName);
                    Helper hp = new Helper();
                    DataTable dt = hp.ConvertCSVtoDataTable(path);
                    hp.InsertIntoTableAppoggio(dt);

                    //SoggImportAppoggio soggetto = new SoggImportAppoggio();
                    //soggetto.selectedId = ente;
                    //file.SaveAs(path);
                    ViewBag.Message = "File caricato con successo";

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
                return RedirectToAction("InLavorazione", "GestioneAnagrafica", new { enteQuerystring = ente });
            }
            else
            {
                ViewBag.Message = "You have not specified a file.";
                return View();
            }
        }

        [HttpGet]
        public ActionResult InLavorazione(string enteQuerystring, string page)
        {
            SoggImportAppoggioSearchResults results = new SoggImportAppoggioSearchResults();

            //Impostare i risultati di ricerca come ancora non trovati è il primo caricamento

            results.CountResults = 0;

            //Utilizzo del servizio wcf per recuperare i dati dal db
            using (HelperService help = new HelperService())
            {
                List<string> enti = help.channel.GetAllEntiInLavorazione();

                //Popolamento della drop down list
                List<SelectListItem> list = new List<SelectListItem>();
                SelectListItem listItemDefault = new SelectListItem() { Value = "0", Text = "Seleziona...", Selected = true };
                list.Add(listItemDefault);

                foreach (string ente in enti)
                {
                    SelectListItem listItem = new SelectListItem() { Value = ente/*ente.IdEnte.ToString()*/, Text = ente };
                    list.Add(listItem);
                }

                results.ListItemEnti = new SelectList(list, "Value", "Text", 0);

                if (!string.IsNullOrEmpty(enteQuerystring))
                {
                    results.Selected = enteQuerystring;
                    results.selectedId = enteQuerystring;
                }
            }
            Session["Ddl"] = results.ListItemEnti;
            results.NumPage = page;
            //soggetto.SearchResults = results;
            return View(results);
        }

        public ActionResult RisultatiSoggettiImportati(SoggImportAppoggioSearchResults modello)
        {
            Search<SoggImportAppoggio> results = new SoggImportAppoggioSearchResults();
            //List<SoggImportAppoggio> soggetti = new List<SoggImportAppoggio>();
            List<SoggettiImportAppoggioDao> _anagrafiche = new List<SoggettiImportAppoggioDao>();
            if (modello.selectedId != null)
            {
                _anagrafiche = (List<SoggettiImportAppoggioDao>)Session["Soggetti"];
                if (!_anagrafiche.Any())
                {
                    using (HelperService help = new HelperService())
                    {
                        _anagrafiche = help.channel.GetSoggettiByEnte(modello.selectedId.ToString());
                    }
                }
                else 
                {
                    _anagrafiche = (List<SoggettiImportAppoggioDao>)Session["Soggetti"];
                }
                #region old
                //foreach (SoggettiImportAppoggioDao _anag in _anagrafiche)
                //{

                //    ErrorsList listaErrori = new ErrorsList();
                //    List<Errore> _errore = new List<Errore>();

                //    foreach (ErroreDao errore in _anag.Errori)
                //    {
                //        Errore _e = new Errore
                //        {
                //            ColumnName = errore.ColumnName,
                //            Description = errore.Description,
                //            Exists = errore.Exist,
                //            ErrorLevel = Enum.Parse(errore.ErrorLevel.GetType(), errore.ErrorLevel.ToString()).ToString()
                //        };
                //        _errore.Add(_e);
                //    }
                //    listaErrori.ListaErrori = _errore;
                //    listaErrori.AllWarnings = _errore.Where(x => x.ErrorLevel.Equals("Warning")).ToList().Count == _errore.Count;

                //    SoggImportAppoggio _sia = new SoggImportAppoggio
                //    {
                //        #region _soggetto
                //        CapResidenza = _anag.CapResidenza,
                //        Categoria = _anag.Categoria,
                //        CodiceFiscaleAssicurato = _anag.CodiceFiscaleAssicurato,
                //        CodiceFiscaleCapoNucleo = _anag.CodiceFiscaleCapoNucleo,
                //        Cognome = _anag.Cognome,
                //        Convenzione = _anag.Convenzione,
                //        DataCessazione = _anag.DataCessazione,
                //        DataNascitaAssicurato = _anag.DataNascitaAssicurato,
                //        Effetto = _anag.Effetto,
                //        Email = _anag.Email,
                //        Ente = _anag.Ente,
                //        EsclusioniPregresse = _anag.EsclusioniPregresse,
                //        Iban = _anag.Iban,
                //        IndirizzoResidenza = _anag.IndirizzoResidenza,
                //        IdSoggetto = _anag.IdSoggetto,
                //        LegameNucleo = _anag.LegameNucleo,
                //        LocalitaResidenza = _anag.LocalitaResidenza,
                //        LuogoNascitaAssicurato = _anag.LuogoNascitaAssicurato,
                //        Nome = _anag.Nome,
                //        NumeroPolizza = _anag.NumeroPolizza,
                //        SecondoNome = _anag.SecondoNome,
                //        SiglaProvResidenza = _anag.SiglaProvResidenza,
                //        Telefono = _anag.Telefono,
                //        Errori = listaErrori
                //        #endregion
                //    };

                //    soggetti.Add(_sia);
                //} 
                #endregion
                results.CountResults = _anagrafiche.Count();


                //results.Results = soggetti;
            }
            else 
            {
                results = modello;
                //soggetti = modello.Results;
            }
            //ViewBag.Soggetti = soggetti;
            Session["Soggetti"] = _anagrafiche;
            ViewBag.Page = modello.NumPage;
            return PartialView(_anagrafiche);
        }

        public ActionResult LoadTable()
        {
            return Json(Session["Soggetti"], JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidaSoggettiImportati() 
        {
            //List<SoggImportAppoggio> soggetti = (List<SoggImportAppoggio>)Session["Soggetti"];
            List<SoggettiImportAppoggioDao> soggDao = (List<SoggettiImportAppoggioDao>)Session["Soggetti"]; //new List<SoggettiImportAppoggioDao>();

            #region old
            //foreach(SoggImportAppoggio _sogg in soggetti)
            //{
            //SoggettiImportAppoggioDao _dao= new SoggettiImportAppoggioDao();
            //    Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggImportAppoggio, SoggettiImportAppoggioDao>.Copy(_sogg, _dao);
            //    soggDao.Add(_dao);
            //} 
            #endregion

                using (HelperService _hp = new HelperService())
                {
                    soggDao = _hp.channel.ValidaSoggetto(soggDao);
                }

                #region old
                //List<SoggImportAppoggio> soggettiValidati = new List<SoggImportAppoggio>();
                //foreach (SoggettiImportAppoggioDao _sogg in soggDao)
                //{
                //    SoggImportAppoggio _dao = new SoggImportAppoggio();
                //    Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggettiImportAppoggioDao, SoggImportAppoggio>.Copy(_sogg, _dao);
                //    soggettiValidati.Add(_dao);
                //}

                //foreach (SoggettiImportAppoggioDao _anag in soggDao)
                //{

                //    ErrorsList listaErrori = new ErrorsList();
                //    List<Errore> _errore = new List<Errore>();

                //    foreach (ErroreDao errore in _anag.Errori)
                //    {
                //        Errore _e = new Errore
                //        {
                //            ColumnName = errore.ColumnName,
                //            Description = errore.Description,
                //            Exists = errore.Exist,
                //            ErrorLevel = Enum.Parse(errore.ErrorLevel.GetType(), errore.ErrorLevel.ToString()).ToString()
                //        };
                //        _errore.Add(_e);
                //    }
                //    listaErrori.ListaErrori = _errore;
                //    listaErrori.AllWarnings = _errore.Where(x => x.ErrorLevel.Equals("Warning")).ToList().Count == _errore.Count;

                //    SoggImportAppoggio _sia = new SoggImportAppoggio
                //    {
                //        #region _soggetto
                //        CapResidenza = _anag.CapResidenza,
                //        Categoria = _anag.Categoria,
                //        CodiceFiscaleAssicurato = _anag.CodiceFiscaleAssicurato,
                //        CodiceFiscaleCapoNucleo = _anag.CodiceFiscaleCapoNucleo,
                //        Cognome = _anag.Cognome,
                //        Convenzione = _anag.Convenzione,
                //        DataCessazione = _anag.DataCessazione,
                //        DataNascitaAssicurato = _anag.DataNascitaAssicurato,
                //        Effetto = _anag.Effetto,
                //        Email = _anag.Email,
                //        Ente = _anag.Ente,
                //        EsclusioniPregresse = _anag.EsclusioniPregresse,
                //        Iban = _anag.Iban,
                //        IndirizzoResidenza = _anag.IndirizzoResidenza,
                //        IdSoggetto = _anag.IdSoggetto,
                //        LegameNucleo = _anag.LegameNucleo,
                //        LocalitaResidenza = _anag.LocalitaResidenza,
                //        LuogoNascitaAssicurato = _anag.LuogoNascitaAssicurato,
                //        Nome = _anag.Nome,
                //        NumeroPolizza = _anag.NumeroPolizza,
                //        SecondoNome = _anag.SecondoNome,
                //        SiglaProvResidenza = _anag.SiglaProvResidenza,
                //        Telefono = _anag.Telefono,
                //        Errori = listaErrori
                //        #endregion
                //    };

                //    soggettiValidati.Add(_sia);
                //}

                //SoggImportAppoggioSearchResults result = new SoggImportAppoggioSearchResults();
                //result.Results = soggettiValidati;
                //result.CountResults = soggettiValidati.Count;
                //result.Selected = soggettiValidati[0].Ente;

                //SoggImportAppoggio toSend = new SoggImportAppoggio();
                //toSend.SearchResults = result;
                ////toSend.selectedId = soggettiValidati[0].Ente;
                //toSend.ListItemEnti = (SelectList)Session["Ddl"]; 
                #endregion
             Session["Soggetti"] = soggDao;

             return PartialView("RisultatiSoggettiImportati",soggDao);
        }

         [HttpGet]
        public ActionResult EditSoggettoImportato(string id) 
        {

            SoggettiImportAppoggioDao soggDao = (from soggetti in (List<SoggettiImportAppoggioDao>)Session["Soggetti"] where soggetti.IdSoggetto.Equals(long.Parse(id)) select soggetti).FirstOrDefault();
            return View(soggDao);
        }

         [HttpPost]
         public ActionResult Modifica(SoggettiImportAppoggioDao modello) 
         {
             string ente = "INAIL";

             return RedirectToAction("InLavorazione", "GestioneAnagrafica", new { enteQuerystring = ente, page = Session["page"].ToString() });
         }
         public ActionResult Back() 
         {
             return RedirectToAction("InLavorazione", "GestioneAnagrafica", new { enteQuerystring = Session["ente"].ToString(), page = Session["page"].ToString() });
         }

    }
}
