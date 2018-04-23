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
    public class T_TipoSoggettoService :IServiceAsdep<T_TipoSoggettoDao>
    {
        AmministrazioneAsdep.AmministrazioneAsdepEntities db;
        T_TipoSoggettoProvider provider;
        public T_TipoSoggettoService()
        {
            provider = new T_TipoSoggettoProvider();
        }

        public int AddOne(T_TipoSoggettoDao obj)
        {
            throw new NotImplementedException();
        }

        public int AddMany(List<T_TipoSoggettoDao> obj)
        {
            throw new NotImplementedException();
        }

        public List<T_TipoSoggettoDao> GetAll()
        {
            List<T_TipoSoggettoDao> _soggDao = new List<T_TipoSoggettoDao>();
            List<T_TipoSoggetto> _tipi = new List<T_TipoSoggetto>();
            try 
            {
                using (db = new AmministrazioneAsdepEntities ())
                {
                    _tipi = provider.GetAll(db);
                }
                foreach (T_TipoSoggetto _t in _tipi) 
                {
                    T_TipoSoggettoDao _dao = new T_TipoSoggettoDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipoSoggetto, T_TipoSoggettoDao>.Copy(_t, _dao);
                    _soggDao.Add(_dao);
                }
               
            }
            catch { }
            return _soggDao;
        }

        public int DeleteOne(T_TipoSoggettoDao obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<T_TipoSoggettoDao> objs)
        {
            throw new NotImplementedException();
        }
    }
}
