using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO
{
    public class T_ErroriIODao
    {
        public string CodTipoErrore { get; set; }
        public string NomeColonna { get; set; }
        public string Colonna { get; set; }
        public string DescErrore { get; set; }
        public string Gravita { get; set; }
        public string InputOutput { get; set; }
        public System.DateTime DataInizio { get; set; }
        public System.DateTime DataFine { get; set; }
        public System.DateTime DataAggiornamento { get; set; }
        public string CodiceUtente { get; set; }
        public string CodAppl { get; set; }

        
    }
}
