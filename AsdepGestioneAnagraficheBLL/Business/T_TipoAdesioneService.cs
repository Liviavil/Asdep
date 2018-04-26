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
    public class T_TipoAdesioneService : IServiceAsdep<T_TipoAdesioneDao>
    {
        AmministrazioneAsdep.AmministrazioneAsdepEntities db;
        T_TipoAdesioneProvider provider;
        public T_TipoAdesioneService()
        {
            provider = new T_TipoAdesioneProvider();
        }


        public int AddOne(T_TipoAdesioneDao obj)
        {
            throw new NotImplementedException();
        }

        public int AddMany(List<T_TipoAdesioneDao> obj)
        {
            throw new NotImplementedException();
        }

        public List<T_TipoAdesioneDao> GetAllCollettiveSelezionabili()
        {
            List<T_TipoAdesioneDao> _tipiAdesioni = new List<T_TipoAdesioneDao>();
            List<T_TipoAdesione> _adesioni = new List<T_TipoAdesione>();
            try 
            {
                using (db=new AmministrazioneAsdep.AmministrazioneAsdepEntities ())
                {
                    _adesioni = provider.GetAllCollettiveSelezionabili(db);
                }

                foreach (T_TipoAdesione _ad in _adesioni) 
                {
                    T_TipoAdesioneDao _dao = new T_TipoAdesioneDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipoAdesione, T_TipoAdesioneDao>.Copy(_ad, _dao);
                    _tipiAdesioni.Add(_dao);
                }
            }
            catch { }
            return _tipiAdesioni;
        }

        public int DeleteOne(T_TipoAdesioneDao obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<T_TipoAdesioneDao> objs)
        {
            throw new NotImplementedException();
        }


        public List<T_TipoAdesioneDao> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool CongruenzaEntePolizza(string adesione, string ente) 
        {
            bool result = false;
            result = provider.CongruenzaEntePolizza(db, adesione, ente);
            return result;
        }
    }
}
