using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class ContribuzioneEnteProvider:IProvider<ContribuzioneEnte>
    {
        public List<ContribuzioneEnte> GetAll(AmministrazioneAsdepEntities db)
        {
            throw new NotImplementedException();
        }

        public ContribuzioneEnte SelectById(AmministrazioneAsdepEntities db, long id)
        {
            throw new NotImplementedException();
        }

        public List<ContribuzioneEnte> Find(AmministrazioneAsdepEntities db, ContribuzioneEnte obj)
        {
            throw new NotImplementedException();
        }

        public int AddOne(AmministrazioneAsdepEntities db, ContribuzioneEnte obb)
        {
            throw new NotImplementedException();
        }

        public int AddMany(AmministrazioneAsdepEntities db, List<ContribuzioneEnte> objs)
        {
            throw new NotImplementedException();
        }

        public int Update(AmministrazioneAsdepEntities db, ContribuzioneEnte obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(AmministrazioneAsdepEntities db, ContribuzioneEnte obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(AmministrazioneAsdepEntities db, List<ContribuzioneEnte> objs)
        {
            throw new NotImplementedException();
        }

        public ContribuzioneEnte SelectByNomeEnte(AmministrazioneAsdepEntities db, string nome)
        {
            ContribuzioneEnte _ce = new ContribuzioneEnte();
            try 
            {
                _ce = (from table in db.Ente
                       join ContrEnte in db.ContribuzioneEnte on table.IdEnte equals ContrEnte.IdEnte
                       where table.CodiceEnte.Equals(nome)
                       select ContrEnte).FirstOrDefault();
            }
            catch { }
            return _ce;
        }
    }
}
