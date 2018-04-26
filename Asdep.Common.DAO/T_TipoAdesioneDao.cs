using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO
{
    public class T_TipoAdesioneDao
    {
        public string CodTipoAdesione { get; set; }
        public string DescBreve { get; set; }
        public string DescTipoAdesione { get; set; }
        public string CategoriaAdesione { get; set; }
        public string RifAdesioneCollettiva { get; set; }
        public Nullable<bool> FlagSelezione { get; set; }
        public System.DateTime DataInizio { get; set; }
        public System.DateTime DataFine { get; set; }
        public System.DateTime DataAggiornamento { get; set; }
        public string CodiceUtente { get; set; }
        public string CodAppl { get; set; }
    }
}
