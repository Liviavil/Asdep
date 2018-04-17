using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO
{
    public class AdesioneDao
    {
        public long IdAdesione { get; set; }
        public string CodTipoAdesione { get; set; }
        public long IdCaponucleo { get; set; }
        public long IdSoggetto { get; set; }
        public string CodTipoSoggetto { get; set; }
        public string CodLegame { get; set; }
        public string FlagPagamentoEnte { get; set; }
        public string FlagPagamentoSoggetto { get; set; }
        public string StatoAdesione { get; set; }
        public string NumeroPratica { get; set; }
        public byte MeseDecorrenza { get; set; }
        public byte MeseScadenza { get; set; }
        public byte AnnoDecorrenza { get; set; }
        public byte AnnoScadenza { get; set; }
        public System.DateTime DataCessazione { get; set; }
        public System.DateTime DataInizio { get; set; }
        public System.DateTime DataFine { get; set; }
        public System.DateTime DataAggiornamento { get; set; }
        public string CodiceUtente { get; set; }
        public string CodAppl { get; set; }
    }
}
