using AmministrazioneAsdep;
using Asdep.Common.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Business
{
    public class T_CategoriaAdesioneService: IServiceAsdep<T_CategoriaAdesioneDao>
    {
        AmministrazioneAsdep.AmministrazioneAsdepEntities db;
        AmministrazioneAsdep.DAL.T_CategoriaAdesioneProvider provider;

        public T_CategoriaAdesioneService()
        {
            provider = new AmministrazioneAsdep.DAL.T_CategoriaAdesioneProvider();
        }


        public int AddOne(T_CategoriaAdesioneDao obj)
        {
            throw new NotImplementedException();
        }

        public int AddMany(List<T_CategoriaAdesioneDao> obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(T_CategoriaAdesioneDao obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<T_CategoriaAdesioneDao> objs)
        {
            throw new NotImplementedException();
        }

        public List<T_CategoriaAdesioneDao> GetAll() 
        {
            List<T_CategoriaAdesioneDao> _categorie = new List<T_CategoriaAdesioneDao>();

            using (db= new AmministrazioneAsdep.AmministrazioneAsdepEntities ())
            {
                List<T_CategoriaAdesione> _cat = new List<T_CategoriaAdesione>();
                _cat = provider.GetAll(db);

                foreach (T_CategoriaAdesione _c in _cat) 
                {
                    T_CategoriaAdesioneDao _catDao = new T_CategoriaAdesioneDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_CategoriaAdesione, T_CategoriaAdesioneDao>.Copy(_c, _catDao);
                    _categorie.Add(_catDao);
                }
                return _categorie;
            }
        }
    }
}
