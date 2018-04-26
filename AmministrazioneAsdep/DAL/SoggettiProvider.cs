using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class SoggettiProvider : IProvider<Soggetto>
    {
        public List<Soggetto> GetAll(AmministrazioneAsdepEntities db)
        {
            throw new NotImplementedException();
        }

        public Soggetto SelectById(AmministrazioneAsdepEntities db, long id)
        {
            throw new NotImplementedException();
        }

        public List<Soggetto> Find(AmministrazioneAsdepEntities db, Soggetto obj)
        {
            throw new NotImplementedException();
        }

        public int AddOne(AmministrazioneAsdepEntities db, Soggetto obb)
        {
            throw new NotImplementedException();
        }

        public int AddMany(AmministrazioneAsdepEntities db, List<Soggetto> objs)
        {
            throw new NotImplementedException();
        }

        public int Update(AmministrazioneAsdepEntities db, Soggetto obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(AmministrazioneAsdepEntities db, Soggetto obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(AmministrazioneAsdepEntities db, List<Soggetto> objs)
        {
            throw new NotImplementedException();
        }

        public Soggetto SelectCNByCF(AmministrazioneAsdepEntities db, string codiceFiscale) 
        {
            Soggetto result = null;
            result = (from SoggettoTable in db.Soggetto join AdeTbl in db.Adesione on SoggettoTable.IdSoggetto equals AdeTbl.IdSoggetto
                      where AdeTbl.CodLegame.Equals("001")
                      && SoggettoTable.CodiceFiscale.Equals(codiceFiscale) select SoggettoTable).FirstOrDefault();
            return result;
        }

        public Soggetto GetByCF(AmministrazioneAsdepEntities db, string valore)
        {
            return (from SoggettoTable in db.Soggetto where SoggettoTable.CodiceFiscale.Equals(valore) select SoggettoTable).FirstOrDefault();
        }
    }
}
