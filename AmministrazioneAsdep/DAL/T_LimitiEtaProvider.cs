using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class T_LimitiEtaProvider:IProvider<T_LimitiEta>
    {

        public bool EtaValida(AmministrazioneAsdepEntities db, int eta, string codAdesione, string codSogg, string codLegame) 
        {
            T_LimitiEta limite = (from Eta in db.T_LimitiEta
                                  where Eta.CodTipoAdesione.Equals(codAdesione) &&
                                      Eta.CodTipoSoggetto.Equals(codSogg) &&
                                      Eta.CodLegame.Equals(codLegame)
                                  select Eta).FirstOrDefault();

            return limite.EtaMinima < eta && eta < limite.EtaMassima;
        }

        public List<T_LimitiEta> GetAll(AmministrazioneAsdepEntities db)
        {
            throw new NotImplementedException();
        }

        public T_LimitiEta SelectById(AmministrazioneAsdepEntities db, long id)
        {
            throw new NotImplementedException();
        }

        public List<T_LimitiEta> Find(AmministrazioneAsdepEntities db, T_LimitiEta obj)
        {
            throw new NotImplementedException();
        }

        public int AddOne(AmministrazioneAsdepEntities db, T_LimitiEta obb)
        {
            throw new NotImplementedException();
        }

        public int AddMany(AmministrazioneAsdepEntities db, List<T_LimitiEta> objs)
        {
            throw new NotImplementedException();
        }

        public int Update(AmministrazioneAsdepEntities db, T_LimitiEta obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(AmministrazioneAsdepEntities db, T_LimitiEta obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(AmministrazioneAsdepEntities db, List<T_LimitiEta> objs)
        {
            throw new NotImplementedException();
        }
    }
}
