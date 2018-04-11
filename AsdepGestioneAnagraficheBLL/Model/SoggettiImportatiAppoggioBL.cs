using AmministrazioneAsdep;
using AsdepGestioneAnagraficheBLL.Extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Model
{
    public class SoggettiImportatiAppoggioBL : SoggettiImportAppoggio
    {
        public List<Errore> Errori
        {
            get;
            set;
        }

        private SoggettiImportAppoggio _as;

        public SoggettiImportatiAppoggioBL(SoggettiImportAppoggio _as)
        {
            // TODO: Complete member initialization
            this._as = _as;
        }
        public SoggettiImportatiAppoggioBL()
            : base()
        {
        }

        public List<Errore> ValidaSoggetto()
        {
            List<Errore> errori = new List<Errore>();
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

            var objFieldNames = typeof(SoggettiImportatiAppoggioBL).GetProperties(flags).Cast<PropertyInfo>().
               Select(item => new
               {
                   Name = item.Name,
                   Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
               }).ToList();

            errori = new List<Errore>();
            foreach (var obj in objFieldNames)
            {
                Errore errore = new Errore();
                errore = Helper.Check(obj.Name, this);
                errori.Add(errore);
            }

            return errori;
        }

    }
}
