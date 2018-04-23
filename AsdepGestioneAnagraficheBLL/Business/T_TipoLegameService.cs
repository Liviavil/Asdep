using AmministrazioneAsdep;
using AmministrazioneAsdep.DAL;
using Asdep.Common.DAO;
using AsdepGestioneAnagraficheBLL.Extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Business
{
    public class T_TipoLegameService: IServiceAsdep<T_TipiLegameDao>
    {
        AmministrazioneAsdepEntities db;

        TipoLegameProvider provider;
        public T_TipoLegameService()
        {
            provider = new TipoLegameProvider();
        }

        public T_TipiLegameDao GetByCodLegame(string codice) 
        {
            T_TipiLegameDao _tipoLegame = new T_TipiLegameDao();
            try 
            {
                using (AmministrazioneAsdepEntities db = new AmministrazioneAsdepEntities())
                {
                    TipoLegameProvider service = new TipoLegameProvider ();
                    T_TipiLegame _tipoDAL = service.GetByCodLegameImport(db, codice);
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipiLegame, T_TipiLegameDao>.Copy(_tipoDAL, _tipoLegame);
                }
            }
            catch { }
            return _tipoLegame;
        }

        public int AddOne(T_TipiLegameDao obj)
        {
            throw new NotImplementedException();
        }

        public int AddMany(List<T_TipiLegameDao> obj)
        {
            throw new NotImplementedException();
        }

        public List<T_TipiLegameDao> GetAll()
        {
            List<T_TipiLegameDao> _tipiLegamidao = new List<T_TipiLegameDao>();
            List<T_TipiLegame> _tipiLEgame = new List<T_TipiLegame>();
            try 
            {
                using (db = new AmministrazioneAsdepEntities ())
                {
                    _tipiLEgame = provider.GetAll(db);
                }
                foreach (T_TipiLegame _t in _tipiLEgame) 
                {
                    T_TipiLegameDao _dao = new T_TipiLegameDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipiLegame, T_TipiLegameDao>.Copy(_t, _dao);
                    _tipiLegamidao.Add(_dao);
                }
            }
            catch { }
            return _tipiLegamidao;
        }

        public int DeleteOne(T_TipiLegameDao obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<T_TipiLegameDao> objs)
        {
            throw new NotImplementedException();
        }
    }
}
