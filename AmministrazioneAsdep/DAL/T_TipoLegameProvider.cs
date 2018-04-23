using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class T_TipoLegameProvider : IProvider<T_TipiLegame>
    {
        public List<T_TipiLegame> GetAll(AmministrazioneAsdepEntities db)
        {
            List<T_TipiLegame> _tipi = new List<T_TipiLegame>();
            try 
            {
                _tipi = (from LegamiTable in db.T_TipiLegame select LegamiTable).ToList();
            }
            catch { }
            return _tipi;
        }

        public T_TipiLegame SelectById(AmministrazioneAsdepEntities db, long id)
        {
            throw new NotImplementedException();
        }

        public List<T_TipiLegame> Find(AmministrazioneAsdepEntities db, T_TipiLegame obj)
        {
            throw new NotImplementedException();
        }

        public int AddOne(AmministrazioneAsdepEntities db, T_TipiLegame obb)
        {
            throw new NotImplementedException();
        }

        public int AddMany(AmministrazioneAsdepEntities db, List<T_TipiLegame> objs)
        {
            throw new NotImplementedException();
        }

        public int Update(AmministrazioneAsdepEntities db, T_TipiLegame obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(AmministrazioneAsdepEntities db, T_TipiLegame obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(AmministrazioneAsdepEntities db, List<T_TipiLegame> objs)
        {
            throw new NotImplementedException();
        }
    }
}
