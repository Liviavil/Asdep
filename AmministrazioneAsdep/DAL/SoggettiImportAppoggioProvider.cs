using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class SoggettiImportAppoggioProvider
    {

        public static List<SoggettiImportAppoggio> GetAllAssicurati(AmministrazioneAsdepEntities db)
        {
            List<SoggettiImportAppoggio> _assicurati = new List<SoggettiImportAppoggio>();
            _assicurati = (from table in db.SoggettiImportAppoggio select table).ToList();

            return _assicurati;
        }

        public static int AddAssicurato(AmministrazioneAsdepEntities db, SoggettiImportAppoggio assicurato)
        {
            int result = -1;
            try
            {
                db.SoggettiImportAppoggio.Add(assicurato);
                result = db.SaveChanges();

                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public static int AddAssicurati(AmministrazioneAsdepEntities db, List<SoggettiImportAppoggio> assicurati)
        {
            int result = -1;
            try
            {
                foreach (SoggettiImportAppoggio _ass in assicurati)
                {
                    db.SoggettiImportAppoggio.Add(_ass);
                    result = db.SaveChanges();
                }

                return result;
            }
            catch (Exception ex) { return -1; }
        }

    }
}
