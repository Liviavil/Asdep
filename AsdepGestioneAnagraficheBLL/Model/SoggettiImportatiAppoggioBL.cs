using AmministrazioneAsdep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Model
{
    public class SoggettiImportatiAppoggioBL : SoggettiImportAppoggio
    {
        private SoggettiImportAppoggio _as;

        public SoggettiImportatiAppoggioBL(SoggettiImportAppoggio _as)
        {
            // TODO: Complete member initialization
            this._as = _as;
        }
        public SoggettiImportatiAppoggioBL() :base()
        {
        }
    }
}
