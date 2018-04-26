using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class ErroriIOProvider : IProvider<T_ErroriIO>
    {

        public List<T_ErroriIO> GetAll(AmministrazioneAsdepEntities db)
        {
            throw new NotImplementedException();
        }

        public T_ErroriIO SelectById(AmministrazioneAsdepEntities db, string id)
        {
            T_ErroriIO _errore = new T_ErroriIO();
            try 
            {
                _errore = (from table in db.T_ErroriIO where table.CodTipoErrore.Equals(id) select table).FirstOrDefault();
            }
            catch { }

            return _errore;
        }

        public List<T_ErroriIO> Find(AmministrazioneAsdepEntities db, T_ErroriIO obj)
        {
            throw new NotImplementedException();
        }

        public int AddOne(AmministrazioneAsdepEntities db, T_ErroriIO obb)
        {
            throw new NotImplementedException();
        }

        public int AddMany(AmministrazioneAsdepEntities db, List<T_ErroriIO> objs)
        {
            throw new NotImplementedException();
        }

        public int Update(AmministrazioneAsdepEntities db, T_ErroriIO obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(AmministrazioneAsdepEntities db, T_ErroriIO obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(AmministrazioneAsdepEntities db, List<T_ErroriIO> objs)
        {
            throw new NotImplementedException();
        }

        public T_ErroriIO SelectById(AmministrazioneAsdepEntities db, long id)
        {
            throw new NotImplementedException();
        }
    }
}
