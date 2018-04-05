﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class EnteProvider : IProvider<Ente>
    {
        public Ente SelectByEnte(AmministrazioneAsdepEntities db, string name)
        {
            Ente _ente = new Ente();
            try 
            {
                _ente = (from table in db.Ente where table.CodiceEnte.Equals(name) select table).FirstOrDefault();
            }
            catch { }
            return _ente;
        }

        public List<Ente> GetAll(AmministrazioneAsdepEntities db)
        {
            List<Ente> _enti = new List<Ente>();
            try 
            {
                _enti = (from table in db.Ente select table).ToList();
            }
            catch { }
            return _enti;
        }

        public Ente SelectById(AmministrazioneAsdepEntities db, string id)
        {
            Ente _ente = new Ente();
            try
            {
                _ente = (from table in db.Ente where table.IdEnte.Equals(id) select table).FirstOrDefault();
            }
            catch { }
            return _ente;
        }

        public List<Ente> Find(AmministrazioneAsdepEntities db, Ente obj)
        {
            throw new NotImplementedException();
        }

        public int AddOne(AmministrazioneAsdepEntities db, Ente obb)
        {
            throw new NotImplementedException();
        }

        public int AddMany(AmministrazioneAsdepEntities db, List<Ente> objs)
        {
            throw new NotImplementedException();
        }

        public int Update(AmministrazioneAsdepEntities db, Ente obj)
        {
            throw new NotImplementedException();
        }
    }
}