using AmministrazioneAsdep;
using AmministrazioneAsdep.DAL;
using Asdep.Common.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Business
{
    public class SoggettoService:IServiceAsdep<SoggettoDao>
    {
        AmministrazioneAsdep.AmministrazioneAsdepEntities db;
        SoggettiProvider provider;
        public SoggettoService()
        {
            provider = new SoggettiProvider();
        }

        public int AddOne(SoggettoDao obj)
        {
            throw new NotImplementedException();
        }

        public int AddMany(List<SoggettoDao> obj)
        {
            throw new NotImplementedException();
        }

        public List<SoggettoDao> GetAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(SoggettoDao obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<SoggettoDao> objs)
        {
            throw new NotImplementedException();
        }

        public SoggettoDao SelectCNByCF(string codiceFiscale) 
        {
            Soggetto soggetto = new Soggetto();
            SoggettoDao _dao = null;
            using (db=new AmministrazioneAsdep.AmministrazioneAsdepEntities ())
            {
                soggetto = provider.SelectCNByCF(db, codiceFiscale);
            }
            if (soggetto != null)
            {
                _dao = new SoggettoDao();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<Soggetto, SoggettoDao>.Copy(soggetto, _dao);
            }
            return _dao;
        }


        public SoggettoDao GetByCF(string valore)
        {
            Soggetto soggetto = new Soggetto();
            SoggettoDao _dao = new SoggettoDao();
            using (db = new AmministrazioneAsdep.AmministrazioneAsdepEntities())
            {
                soggetto = provider.GetByCF(db, valore);
            }
            Asdep.Common.DAO.ExtraDao.PropertyCopier<Soggetto, SoggettoDao>.Copy(soggetto, _dao);
            return _dao;
        }
    }
}
