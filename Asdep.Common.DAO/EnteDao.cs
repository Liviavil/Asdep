using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO
{
    public class EnteDao
    {
        public long IdEnte { get; set; }
        public string CodiceFiscale { get; set; }
        public string Progressivo { get; set; }
        public string RagioneSociale { get; set; }
        public string CodiceEnte { get; set; }
        public System.DateTime DataInizio { get; set; }
        public System.DateTime DataFine { get; set; }
        public System.DateTime DataAggiornamento { get; set; }
        public string CodiceUtente { get; set; }
        public string CodAppl { get; set; }
    }
}
