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
            throw new NotImplementedException();
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
