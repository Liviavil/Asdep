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
    public class ContribuzioneEnteService: IServiceAsdep<ContribuzioneEnteDao>
    {
        private AmministrazioneAsdepEntities db;
        private ContribuzioneEnteProvider provider;
        public ContribuzioneEnteService()
        {
            provider = new ContribuzioneEnteProvider();
        }

        public int AddOne(ContribuzioneEnteDao obj)
        {
            throw new NotImplementedException();
        }

        public int AddMany(List<ContribuzioneEnteDao> obj)
        {
            throw new NotImplementedException();
        }

        public List<ContribuzioneEnteDao> GetAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(ContribuzioneEnteDao obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<ContribuzioneEnteDao> objs)
        {
            throw new NotImplementedException();
        }

        public ContribuzioneEnteDao SelectByNomeEnte(string nome) 
        {
            ContribuzioneEnteDao _eDao = new ContribuzioneEnteDao();
            ContribuzioneEnte _e = new ContribuzioneEnte();
            try 
            {
                using (db= new AmministrazioneAsdepEntities ())
                {
                    _e = provider.SelectByNomeEnte(db, nome);
                }
                Asdep.Common.DAO.ExtraDao.PropertyCopier<ContribuzioneEnte, ContribuzioneEnteDao>.Copy(_e, _eDao);
            }
            catch { }
            return _eDao;
        }
    }
}
