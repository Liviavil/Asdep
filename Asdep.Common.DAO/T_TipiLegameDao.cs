using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO
{
    public class T_TipiLegameDao
    {
        public string CodLegame { get; set; }
        public string DescLegame { get; set; }
        public string FlagCarico { get; set; }
        public string CodTipoCarico { get; set; }
        public string CodLegameImport { get; set; }
        public string CodLegameExport { get; set; }
        public string CodTipoCaricoExport { get; set; }
        public Nullable<byte> EtaMinima { get; set; }
        public Nullable<byte> EtaMassima { get; set; }
        public System.DateTime DataInizio { get; set; }
        public System.DateTime DataFine { get; set; }
        public System.DateTime DataAggiornamento { get; set; }
        public string CodiceUtente { get; set; }
        public string CodAppl { get; set; }
    }
}
