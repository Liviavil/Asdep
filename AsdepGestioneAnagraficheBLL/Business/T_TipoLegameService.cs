using AmministrazioneAsdep;
using AmministrazioneAsdep.DAL;
using AsdepGestioneAnagraficheBLL.Extra;
using AsdepGestioneAnagraficheBLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Business
{
    public class T_TipoLegameService: IServiceAsdep<T_TipoLegameBL>
    {

        public T_TipoLegameBL GetByCodLegame(string codice) 
        {
            T_TipoLegameBL _tipoLegame = new T_TipoLegameBL();
            try 
            {
                using (AmministrazioneAsdepEntities db = new AmministrazioneAsdepEntities())
                {
                    TipoLegameProvider service = new TipoLegameProvider ();
                    T_TipiLegame _tipoDAL = service.GetByCodLegameImport(db, codice);
                    Helper.PropertyCopier<T_TipiLegame, T_TipoLegameBL>.Copy(_tipoDAL, _tipoLegame);
                }
            }
            catch { }
            return _tipoLegame;
        }

        public int AddOne(T_TipoLegameBL obj)
        {
            throw new NotImplementedException();
        }

        public int AddMany(List<T_TipoLegameBL> obj)
        {
            throw new NotImplementedException();
        }

        public List<T_TipoLegameBL> GetAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(T_TipoLegameBL obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<T_TipoLegameBL> objs)
        {
            throw new NotImplementedException();
        }
    }
}
