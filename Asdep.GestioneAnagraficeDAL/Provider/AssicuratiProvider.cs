using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.GestioneAnagraficeDAL.Provider
{
    public class AssicuratiProvider
    {

        public static List<ASSICURATI> GetAllAssicurati(ASSICURATI_ASDEPEntities db)
        {
            List<ASSICURATI> _assicurati = new List<ASSICURATI>();
            _assicurati = (from table in db.ASSICURATI select table).ToList();

            return _assicurati;
        }

        public static int AddAssicurato(ASSICURATI_ASDEPEntities db, ASSICURATI assicurato)
        {
            int result = -1;
            try
            {
                db.ASSICURATI.Add(assicurato);
                result = db.SaveChanges();

                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public static int AddAssicurati(ASSICURATI_ASDEPEntities db, List<ASSICURATI> assicurati)
        {
            int result = -1;
            try
            {
                foreach (ASSICURATI _ass in assicurati)
                {
                    db.ASSICURATI.Add(_ass);
                    result = db.SaveChanges();
                }

                return result;
            }
            catch (Exception ex) { return -1; }
        }
    }
}
