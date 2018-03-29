using Asdep.GestioneAnagraficeDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Model
{
    public class AssicuratiBL : ASSICURATI
    {
        private ASSICURATI _as;

        public AssicuratiBL(ASSICURATI _as)
        {
            // TODO: Complete member initialization
            this._as = _as;
        }
        public AssicuratiBL()
        {
        }
    }
}
