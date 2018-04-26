using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO
{
    public class T_LimitiEtaDao
    {
        public string CodTipoAdesione { get; set; }
        public string CodTipoSoggetto { get; set; }
        public string CodLegame { get; set; }
        public System.DateTime DataInizio { get; set; }
        public Nullable<byte> EtaMinima { get; set; }
        public Nullable<byte> EtaMassima { get; set; }
        public System.DateTime DataFine { get; set; }
        public System.DateTime DataAggiornamento { get; set; }
        public string CodiceUtente { get; set; }
        public string CodAppl { get; set; }
    }
}
