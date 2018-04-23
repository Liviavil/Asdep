using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class T_TipoSoggettoProvider:IProvider<T_TipoSoggetto>
    {
        public List<T_TipoSoggetto> GetAll(AmministrazioneAsdepEntities db)
        {
            List<T_TipoSoggetto> _tipi = new List<T_TipoSoggetto>();
            try 
            {
                _tipi = (from TipoSoggettoTable in db.T_TipoSoggetto select TipoSoggettoTable).ToList();
            }
            catch { }
            return _tipi;
        }

        public T_TipoSoggetto SelectById(AmministrazioneAsdepEntities db, long id)
        {
            throw new NotImplementedException();
        }

        public List<T_TipoSoggetto> Find(AmministrazioneAsdepEntities db, T_TipoSoggetto obj)
        {
            throw new NotImplementedException();
        }

        public int AddOne(AmministrazioneAsdepEntities db, T_TipoSoggetto obb)
        {
            throw new NotImplementedException();
        }

        public int AddMany(AmministrazioneAsdepEntities db, List<T_TipoSoggetto> objs)
        {
            throw new NotImplementedException();
        }

        public int Update(AmministrazioneAsdepEntities db, T_TipoSoggetto obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(AmministrazioneAsdepEntities db, T_TipoSoggetto obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(AmministrazioneAsdepEntities db, List<T_TipoSoggetto> objs)
        {
            throw new NotImplementedException();
        }
    }
}
