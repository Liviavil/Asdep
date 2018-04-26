using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebApp.CustomCode;
using System.Web.Mvc;
using System.ComponentModel;

namespace MvcWebApp.Models
{
    public class SoggImportAppoggio
    {

        public long IdSoggetto { get; set; }
        public string Convenzione { get; set; }
        public string Categoria { get; set; }
        public string EsclusioniPregresse { get; set; }
        public string NumeroPolizza { get; set; }
        public string Ente { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string SecondoNome { get; set; }
        public string CodiceFiscaleCapoNucleo { get; set; }
        public string CodiceFiscaleAssicurato { get; set; }
        public string LuogoNascitaAssicurato { get; set; }
        public DateTime? DataNascitaAssicurato { get; set; }
        public string LegameNucleo { get; set; }
        public DateTime? Effetto { get; set; }
        public string IndirizzoResidenza { get; set; }
        public string LocalitaResidenza { get; set; }
        public string SiglaProvResidenza { get; set; }
        public string CapResidenza { get; set; }
        public string Iban { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime? DataCessazione { get; set; }
        public ErrorsList Errori { get; set; }
        
        //public SoggImportAppoggioSearchResults SearchResults { get; set; }
    }

    public class SoggImportAppoggioSearchResults : Search<SoggImportAppoggio>
    {
        public string selectedId { get; set; }
        public SelectList ListItemEnti { get; set; }
        public string NumPage { get; set; }

        public SelectList ListTracciati { get; set; }
        public string selectedTracciato { get; set; }
    }

    public class ErrorsList
    {
        public List<Errore> ListaErrori { get; set; }
        public bool AllWarnings { get; set; }
    }

    public class Errore
    {
        public string ColumnName { get; set; }
        public string Description { get; set; }
        public string ErrorLevel { get; set; }
        public bool Exists { get; set; }

    }

}