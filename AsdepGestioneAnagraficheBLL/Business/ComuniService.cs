using AmministrazioneAsdep.DAL;
using Asdep.Common.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Business
{
    public class ComuniService : IServiceAsdep<ComuniDao>
    {
        AmministrazioneAsdep.AmministrazioneAsdepEntities db;
        ComuniProvider provider;
        public ComuniService()
        {
            provider = new ComuniProvider();
        }

        public bool FindSiglaProvincia(string prov) 
        {
            using (db=new AmministrazioneAsdep.AmministrazioneAsdepEntities ())
            {
                return provider.SiglaProvincia(db, prov);
            }
        }

        public int AddOne(ComuniDao obj)
        {
            throw new NotImplementedException();
        }

        public int AddMany(List<ComuniDao> obj)
        {
            throw new NotImplementedException();
        }

        public List<ComuniDao> GetAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(ComuniDao obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<ComuniDao> objs)
        {
            throw new NotImplementedException();
        }
    }
}
