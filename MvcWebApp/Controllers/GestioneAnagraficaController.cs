using MvcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcWebApp.CustomCode;
using System.ServiceModel.Web;
using WcfService;

namespace MvcWebApp.Controllers
{
    public class GestioneAnagraficaController : Controller
    {
        //
        // GET: /InLavorazione/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InLavorazione()
        {
            SoggImportAppoggio soggetto = new SoggImportAppoggio();
            
            //Impostare i risultati di ricerca come ancora non trovati è il primo caricamento
            SoggImportAppoggioSearchResults results = new SoggImportAppoggioSearchResults();
            results.CountResults = 0;


            //Utilizzo del servizio wcf per recuperare i dati dal db
            using (HelperService help = new HelperService ())
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
                soggetto.SearchResults = results;
                
            }

            return View(soggetto); 
        }

        public ActionResult RisultatiSoggettiImportati(SoggImportAppoggio modello) 
        {
            Search<SoggImportAppoggio> results = new SoggImportAppoggioSearchResults();
            List<SoggImportAppoggio> soggetti = new List<SoggImportAppoggio>();

            using (HelperService help = new HelperService ())
            {
                List<WcfService.DAL.Anagrafica> _anagrafiche = help.channel.GetSoggettiByEnte(modello.selectedId.ToString());

                foreach (WcfService.DAL.Anagrafica _anag in _anagrafiche) 
                {
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
                        Telefono = _anag.Telefono
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
