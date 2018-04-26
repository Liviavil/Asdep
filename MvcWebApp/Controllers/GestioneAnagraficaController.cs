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
            string ente = "";
            string codiceEnte = "";
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string path = Path.GetFileName(file.FileName);
                    ente = path.Split('_')[0].ToString();
                    using (HelperService _hp = new HelperService())
                    {
                        codiceEnte = _hp.channel.GetAllEnti().Where(x => x.CodiceEnte.Equals(ente)).FirstOrDefault().CodiceEnte;
                    }
                    if (!string.IsNullOrEmpty(codiceEnte))
                    {
                        Helper hp = new Helper();
                        DataTable dt = hp.ConvertCSVtoDataTable(path);
                        hp.InsertIntoTableAppoggio(dt, "Prima adesione/Rinnovo");
                        ViewBag.Message = "File caricato con successo";
                        return RedirectToAction("InLavorazione", "GestioneAnagrafica", new { en = ente, tt = "Prima adesione/Rinnovo" });
                    }
                    else { return View(); }

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERRORE:Ente non censito";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Il tracciato importato è vuoto, riprovare con un altro file.";
                return View();
            }
        }

        [HttpGet]

        public ActionResult InLavorazione(string en, string page, string tt)
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

                List<SelectListItem> listTracciati = new List<SelectListItem>();
                SelectListItem listitem1 = new SelectListItem() { Value = "Prima adesione/Rinnovo", Text = "Prima adesione/Rinnovo" };
                SelectListItem listitem2 = new SelectListItem() { Value = "Esclusioni", Text = "Esclusioni" };
                SelectListItem listitem3 = new SelectListItem() { Value = "Inclusioni", Text = "Inclusioni" };
                listTracciati.Add(listitem1);
                listTracciati.Add(listitem2);
                listTracciati.Add(listitem3);


                results.ListItemEnti = new SelectList(list, "Value", "Text", 0);
                results.ListTracciati = new SelectList(listTracciati, "Value", "Text", 0);

                if (!string.IsNullOrEmpty(en))
                {
                    results.Selected = en;
                    results.selectedId = en;
                }
                if (!string.IsNullOrEmpty(tt))
                {
                    results.selectedTracciato = tt;
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
            if (modello.selectedId != null && modello.selectedTracciato != null)
            {

                using (HelperService help = new HelperService())
                {
                    _anagrafiche = help.channel.GetSoggettiByEnte(modello.selectedId.ToString(), modello.selectedTracciato.ToString());
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
                _hp.channel.ValidaSoggetto(soggDao, soggDao[0].TipoTracciato);
                soggDao = _hp.channel.GetSoggettiByEnte(soggDao[0].Ente, soggDao[0].TipoTracciato);
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

            return PartialView("RisultatiSoggettiImportati", soggDao);
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
            string ente = modello.Ente;
            long idSoggetto = modello.IdSoggetto;
            SoggettiImportAppoggioDao modelloValidato = new SoggettiImportAppoggioDao();
            using (HelperService _hp = new HelperService())
            {
                _hp.channel.ValidaSoggettoSingolo(modello,modello.TipoTracciato);
                modelloValidato = _hp.channel.SelectById(idSoggetto);
            }
            if (!modelloValidato.Errori.Any())
            {
                return RedirectToAction("InLavorazione", "GestioneAnagrafica", new { en = ente, page = Session["page"].ToString() });
            }
            else
            {
                return View("EditSoggettoImportato", modelloValidato);
            }
        }
        public ActionResult Back()
        {
            return RedirectToAction("InLavorazione", "GestioneAnagrafica", new { en = Session["ente"].ToString(), page = Session["page"].ToString() });
        }

        [HttpGet]
        public ActionResult Scarta(string id)
        {
            SoggettiImportAppoggioDao soggetto = new SoggettiImportAppoggioDao();
            using (HelperService _hp = new HelperService())
            {
                _hp.channel.DeleteSoggettoImportato(long.Parse(id));
            }

            return RedirectToAction("InLavorazione", "GestioneAnagrafica", new { en = Session["ente"].ToString(), page = Session["page"].ToString() });
        }

        public ActionResult InviaAdesione(string cf, string page, string tipoTracciato)
        {
            SoggettiImportAppoggioDao soggetto = new SoggettiImportAppoggioDao();
            using (HelperService _hp = new HelperService())
            {
                _hp.channel.InviaAdesioneSoggettiImportati(cf, tipoTracciato);
            }


            return RedirectToAction("InLavorazione", "GestioneAnagrafica", new { en = Session["ente"].ToString(), page = Session["page"].ToString() });
        }

        public ActionResult CaricaEsclusioni(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string path = Path.GetFileName(file.FileName);
                string ente = path.Split('_')[0].ToString();
                using (HelperService _hp = new HelperService())
                {
                    string codiceEnte = _hp.channel.GetAllEnti().Where(x => x.CodiceEnte.Equals(ente)).Select(y => y.CodiceEnte).ToString();
                    if (!string.IsNullOrEmpty(codiceEnte))
                    {
                        Helper hp = new Helper();
                        DataTable dt = hp.ConvertCSVtoDataTable(path);
                        hp.InsertIntoTableAppoggio(dt, "Esclusioni");
                        return RedirectToAction("InLavorazione", "GestioneAnagrafica", new { en = ente });
                    }
                    else
                    {
                        ViewBag.Message = "Codice ente specificato nel tracciato non censito.";
                        return View();
                    }
                }
            }
            else
            {
                ViewBag.Message = "Il tracciato caricato è vuoto.";
                return View();
            }
        }

        public ActionResult CaricaInclusioni(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string path = Path.GetFileName(file.FileName);
                string ente = path.Split('_')[0].ToString();
                using (HelperService _hp = new HelperService())
                {
                    string codiceEnte = _hp.channel.GetAllEnti().Where(x => x.CodiceEnte.Equals(ente)).Select(y => y.CodiceEnte).ToString();
                    if (!string.IsNullOrEmpty(codiceEnte))
                    {
                        Helper hp = new Helper();
                        DataTable dt = hp.ConvertCSVtoDataTable(path);
                        hp.InsertIntoTableAppoggio(dt, "Inclusioni");
                        return RedirectToAction("InLavorazione", "GestioneAnagrafica", new { en = ente });
                    }
                    else
                    {
                        ViewBag.Message = "Codice ente specificato nel tracciato non censito.";
                        return View();
                    }
                }
            }
            else
            {
                ViewBag.Message = "Il tracciato caricato è vuoto.";
                return View();
            }
        }

    }
}
