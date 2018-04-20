using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO
{
    public class SoggettiImportAppoggioDao
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
        public Nullable<System.DateTime> DataNascitaAssicurato { get; set; }
        public string LegameNucleo { get; set; }
        public Nullable<System.DateTime> Effetto { get; set; }
        public string IndirizzoResidenza { get; set; }
        public string LocalitaResidenza { get; set; }
        public string SiglaProvResidenza { get; set; }
        public string CapResidenza { get; set; }
        public string Iban { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Nullable<System.DateTime> DataCessazione { get; set; }

        public List<T_ErroriIODao> Errori { get; set; }
        public bool AllWarnings { get; set; }

        
    }
}
