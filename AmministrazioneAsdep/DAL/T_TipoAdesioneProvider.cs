using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class T_TipoAdesioneProvider: IProvider<T_TipoAdesione>
    {
        public List<T_TipoAdesione> GetAllCollettiveSelezionabili(AmministrazioneAsdepEntities db)
        {
            List<T_TipoAdesione> _tipi = new List<T_TipoAdesione>();

            try 
            {
                _tipi = (from TipoAdesioneTable in db.T_TipoAdesione
                         where TipoAdesioneTable.FlagSelezione == true
                         select TipoAdesioneTable).ToList();
            }
            catch { }
            return _tipi;
        }

        public List<T_TipoAdesione> GetAll(AmministrazioneAsdepEntities db)
        {
            throw new NotImplementedException();
        }

        public T_TipoAdesione SelectById(AmministrazioneAsdepEntities db, long id)
        {
            throw new NotImplementedException();
        }

        public List<T_TipoAdesione> Find(AmministrazioneAsdepEntities db, T_TipoAdesione obj)
        {
            throw new NotImplementedException();
        }

        public int AddOne(AmministrazioneAsdepEntities db, T_TipoAdesione obb)
        {
            throw new NotImplementedException();
        }

        public int AddMany(AmministrazioneAsdepEntities db, List<T_TipoAdesione> objs)
        {
            throw new NotImplementedException();
        }

        public int Update(AmministrazioneAsdepEntities db, T_TipoAdesione obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(AmministrazioneAsdepEntities db, T_TipoAdesione obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(AmministrazioneAsdepEntities db, List<T_TipoAdesione> objs)
        {
            throw new NotImplementedException();
        }

        public bool CongruenzaEntePolizza(AmministrazioneAsdepEntities db, string descAdesione, string ente) 
        {
            bool result = false;
            string polizza = (from ContrEnteTable in db.ContribuzioneEnte
                              join
                                  AdesioneTable in db.T_TipoAdesione on ContrEnteTable.CodTipoAdesione equals AdesioneTable.CodTipoAdesione
                              where ContrEnteTable.Ente.CodiceEnte.Equals(ente)
                              select AdesioneTable.DescBreve).FirstOrDefault().ToString();
            if (polizza.Equals(descAdesione))
                result = true;
            return result;
        }
    }
}
