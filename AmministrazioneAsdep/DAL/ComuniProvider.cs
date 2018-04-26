using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class ComuniProvider:IProvider<Comuni>
    {
        public bool SiglaProvincia(AmministrazioneAsdepEntities db, string prov) 
        {
            Comuni comune = null;
            comune = (from ComuniTable in db.Comuni where ComuniTable.SiglaProvincia.Equals(prov) select ComuniTable).FirstOrDefault();
            return comune != null;
        }
        public List<Comuni> GetAll(AmministrazioneAsdepEntities db)
        {
            throw new NotImplementedException();
        }

        public Comuni SelectById(AmministrazioneAsdepEntities db, long id)
        {
            throw new NotImplementedException();
        }

        public List<Comuni> Find(AmministrazioneAsdepEntities db, Comuni obj)
        {
            throw new NotImplementedException();
        }

        public int AddOne(AmministrazioneAsdepEntities db, Comuni obb)
        {
            throw new NotImplementedException();
        }

        public int AddMany(AmministrazioneAsdepEntities db, List<Comuni> objs)
        {
            throw new NotImplementedException();
        }

        public int Update(AmministrazioneAsdepEntities db, Comuni obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(AmministrazioneAsdepEntities db, Comuni obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(AmministrazioneAsdepEntities db, List<Comuni> objs)
        {
            throw new NotImplementedException();
        }
    }
}
