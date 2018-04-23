using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class T_CategoriaAdesioneProvider: IProvider<T_CategoriaAdesione>
    {

        public List<T_CategoriaAdesione> GetAll(AmministrazioneAsdepEntities db)
        {
            List<T_CategoriaAdesione> _categorie = new List<T_CategoriaAdesione>();
            try 
            {
                _categorie = (from CateTable in db.T_CategoriaAdesione select CateTable).ToList();
            }
            catch { }
            return _categorie;
        }

        public T_CategoriaAdesione SelectById(AmministrazioneAsdepEntities db, long id)
        {
            throw new NotImplementedException();
        }

        public List<T_CategoriaAdesione> Find(AmministrazioneAsdepEntities db, T_CategoriaAdesione obj)
        {
            throw new NotImplementedException();
        }

        public int AddOne(AmministrazioneAsdepEntities db, T_CategoriaAdesione obb)
        {
            throw new NotImplementedException();
        }

        public int AddMany(AmministrazioneAsdepEntities db, List<T_CategoriaAdesione> objs)
        {
            throw new NotImplementedException();
        }

        public int Update(AmministrazioneAsdepEntities db, T_CategoriaAdesione obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(AmministrazioneAsdepEntities db, T_CategoriaAdesione obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(AmministrazioneAsdepEntities db, List<T_CategoriaAdesione> objs)
        {
            throw new NotImplementedException();
        }
    }
}
