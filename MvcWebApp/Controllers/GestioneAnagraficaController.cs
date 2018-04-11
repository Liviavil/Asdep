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
                    hp.InitializeWorkbook(path);
                    hp.ConvertToDataTable();

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
        public ActionResult InLavorazione(string enteQuerystring)
        {
            SoggImportAppoggio soggetto = new SoggImportAppoggio();
            SoggImportAppoggioSearchResults results = new SoggImportAppoggioSearchResults();

            //Impostare i risultati di ricerca come ancora non trovati è il primo caricamento

            results.CountResults = 0;

            //Utilizzo del servizio wcf per recuperare i dati dal db
            using (HelperService help = new HelperService())
            {
                List<WcfService.DAL.Ente> enti = help.channel.GetAllEnti();

                //Popolamento della drop down list
                List<SelectListItem> list = new List<SelectListItem>();
                SelectListItem listItemDefault = new SelectListItem() { Value = "0", Text = "Seleziona...", Selected = true };
                list.Add(listItemDefault);

                foreach (WcfService.DAL.Ente ente in enti)
                {
                    SelectListItem listItem = new SelectListItem() { Value = ente.CodiceEnte/*ente.IdEnte.ToString()*/, Text = ente.CodiceEnte };
                    list.Add(listItem);
                }

                soggetto.ListItemEnti = new SelectList(list, "Value", "Text", 0);

                if (!string.IsNullOrEmpty(enteQuerystring))
                {
                    results.Selected = enteQuerystring;
                    soggetto.selectedId = enteQuerystring;
                }
            }
            soggetto.SearchResults = results;
            return View(soggetto);
        }

        public ActionResult RisultatiSoggettiImportati(SoggImportAppoggio modello)
        {
            Search<SoggImportAppoggio> results = new SoggImportAppoggioSearchResults();
            List<SoggImportAppoggio> soggetti = new List<SoggImportAppoggio>();

            using (HelperService help = new HelperService())
            {
                List<WcfService.DAL.Anagrafica> _anagrafiche = help.channel.GetSoggettiByEnte(modello.selectedId.ToString());

                foreach (WcfService.DAL.Anagrafica _anag in _anagrafiche)
                {
                    ErrorsList listaErrori = new ErrorsList();

                    List<Errore> _errore = new List<Errore>();
                    foreach (WcfService.DAL.Errore errore in _anag.Errori)
                    {
                        Errore _e = new Errore 
                        { 
                            ColumnName = errore.ColumnName, 
                            Description = errore.Description, 
                            Exists = errore.Exists ,
                            ErrorLevel= Enum.Parse(errore.ErrorLevel.GetType(),errore.ErrorLevel.ToString()).ToString()
                        };
                        _errore.Add(_e);
                    }
                    listaErrori.ListaErrori = _errore;
                    listaErrori.AllWarnings = _errore.Where(x => x.ErrorLevel.Equals("Warning")).ToList().Count == _errore.Count;

                    SoggImportAppoggio _sia = new SoggImportAppoggio
                    {
                        #region _soggetto
                        CapResidenza = _anag.CapResidenza,
                        Categoria = _anag.Categoria,
                        CodiceFiscaleAssicurato = _anag.CodiceFiscaleAssicurato,
                        CodiceFiscaleCapoNucleo = _anag.CodiceFiscaleCapoNucleo,
                        Cognome = _anag.Cognome,
                        Convenzione = _anag.Convenzione,
                        DataCessazione = _anag.DataCessazione,
                        DataNascitaAssicurato = _anag.DataNascitaAssicurato,
                        Effetto = _anag.Effetto,
                        Email = _anag.Email,
                        Ente = _anag.Ente,
                        EsclusioniPregresse = _anag.Esclusioni,
                        Iban = _anag.Iban,
                        IndirizzoResidenza = _anag.IndirizzoResidenza,
                        IdSoggetto = _anag.IdSoggetto,
                        LegameNucleo = _anag.LegameNucleo,
                        LocalitaResidenza = _anag.LocalitaResidenza,
                        LuogoNascitaAssicurato = _anag.LuogoNascitaAssicurato,
                        Nome = _anag.Nome,
                        NumeroPolizza = _anag.NumeroPolizza,
                        SecondoNome = _anag.SecondoNome,
                        SiglaProvResidenza = _anag.SiglaProvResidenza,
                        Telefono = _anag.Telefono,
                        Errori = listaErrori
                        #endregion
                    };

                    soggetti.Add(_sia);
                }
                results.CountResults = _anagrafiche.Count();
            }

            results.Results = soggetti;
            //ViewBag.Soggetti = soggetti;
            Session["Soggetti"] = soggetti;
            return PartialView(results);
        }

        public ActionResult LoadTable()
        {
            return Json(Session["Soggetti"], JsonRequestBehavior.AllowGet);
        }

    }
}
