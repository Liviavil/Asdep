using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebApp.CustomCode;
using System.Web.Mvc;

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

        public string selectedId { get; set; }
        public SelectList ListItemEnti { get; set; }
        public SoggImportAppoggioSearchResults SearchResults { get; set; }
    }

    public class SoggImportAppoggioSearchResults : Search<SoggImportAppoggio> 
    {
    }

}