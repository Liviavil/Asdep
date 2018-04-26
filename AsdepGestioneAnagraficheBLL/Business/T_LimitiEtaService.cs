using AmministrazioneAsdep.DAL;
using Asdep.Common.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Business
{
    public class T_LimitiEtaService: IServiceAsdep<T_LimitiEtaDao>
    {
        AmministrazioneAsdep.AmministrazioneAsdepEntities db;
        T_LimitiEtaProvider provider;

        public T_LimitiEtaService()
        {
            provider = new T_LimitiEtaProvider();
        }

        public bool EtaValida(int eta, string codAdesione, string codSogg, string codLegame) 
        {
            using (db=new AmministrazioneAsdep.AmministrazioneAsdepEntities ())
            {
                return provider.EtaValida(db, eta, codAdesione, codSogg, codLegame);
            }
        }

        public int AddOne(T_LimitiEtaDao obj)
        {
            throw new NotImplementedException();
        }

        public int AddMany(List<T_LimitiEtaDao> obj)
        {
            throw new NotImplementedException();
        }

        public List<T_LimitiEtaDao> GetAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(T_LimitiEtaDao obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<T_LimitiEtaDao> objs)
        {
            throw new NotImplementedException();
        }
    }
}
