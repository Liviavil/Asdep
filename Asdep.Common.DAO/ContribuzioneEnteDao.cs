using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO
{
    public class ContribuzioneEnteDao
    {
        public long IdEnte { get; set; }
        public string CodTipoAdesione { get; set; }
        public System.DateTime DataInizioAdesione { get; set; }
        public Nullable<decimal> PercentualeQuota { get; set; }
        public Nullable<decimal> ValoreAssolutoQuota { get; set; }
        public string NumeroPolizza { get; set; }
        public System.DateTime DataFine { get; set; }
        public System.DateTime DataAggiornamento { get; set; }
        public System.DateTime DataRinnovo { get; set; }
        public string CodiceUtente { get; set; }
        public string CodAppl { get; set; }
    }
}
