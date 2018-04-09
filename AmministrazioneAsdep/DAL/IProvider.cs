using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public interface IProvider<T> where T : class
    {
        List<T> GetAll(AmministrazioneAsdepEntities db);

        T SelectById(AmministrazioneAsdepEntities db, long id);

        List<T> Find(AmministrazioneAsdepEntities db, T obj);

        int AddOne(AmministrazioneAsdepEntities db, T obb);

        int AddMany(AmministrazioneAsdepEntities db, List<T> objs);

        int Update(AmministrazioneAsdepEntities db, T obj);

        int DeleteOne(AmministrazioneAsdepEntities db, T obj);

        int DeleteMany(AmministrazioneAsdepEntities db, List<T> objs);

    }
}
