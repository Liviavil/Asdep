using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO
{
    public class ComuniDao
    {
        public long IdComune { get; set; }
        public string CodCop { get; set; }
        public string DescComune { get; set; }
        public string SiglaProvincia { get; set; }
        public string FlagEstero { get; set; }
        public System.DateTime DataInizio { get; set; }
        public System.DateTime DataFine { get; set; }
        public System.DateTime DataAggiornamento { get; set; }
        public string CodiceUtente { get; set; }
        public string CodAppl { get; set; }
    }
}
