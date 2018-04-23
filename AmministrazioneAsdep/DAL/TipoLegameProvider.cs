using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class TipoLegameProvider : IProvider<T_TipiLegame>
    {
        public T_TipiLegame GetByCodLegameImport(AmministrazioneAsdepEntities db, string codice) 
        {
            T_TipiLegame _tipoLegame = new T_TipiLegame();
            try 
            {
                _tipoLegame = (from table in db.T_TipiLegame where table.CodLegameImport.Equals(codice) select table).FirstOrDefault();
            }
                
            catch { }
            return _tipoLegame;
        }

        public List<T_TipiLegame> GetAll(AmministrazioneAsdepEntities db)
        {
            List<T_TipiLegame> _tipiLegame = new List<T_TipiLegame>();
            try 
            {
                _tipiLegame = (from LegameTable in db.T_TipiLegame select LegameTable).ToList();
            }
            catch { }
            return _tipiLegame;
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
