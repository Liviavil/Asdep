using AmministrazioneAsdep;
using AmministrazioneAsdep.DAL;
using AsdepGestioneAnagraficheBLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Business
{
    public class EnteService : IServiceAsdep<EnteBL>
    {
        private AmministrazioneAsdepEntities db;

        public EnteService()
        {
            db = new AmministrazioneAsdepEntities();
        }
        public EnteBL SelectByCodiceEnte(string name) 
        {
            Ente _ente = new Ente();
            EnteBL _eBL = null;
            using (db)
            {
                EnteProvider provider = new EnteProvider();
                _ente = provider.SelectByEnte(db, name);
            }

            if (_ente != null || _ente.ToString().Equals(string.Empty))
            {
                _eBL = new EnteBL
                {
                    CodAppl = _ente.CodAppl,
                    CodiceEnte = _ente.CodiceEnte,
                    CodiceFiscale = _ente.CodiceFiscale,
                    CodiceUtente = _ente.CodiceUtente,
                    ContribuzioneEnte = _ente.ContribuzioneEnte,
                    DataAggiornamento = _ente.DataAggiornamento,
                    DataFine = _ente.DataFine,
                    DataInizio = _ente.DataInizio,
                    EnteAppartenenza = _ente.EnteAppartenenza,
                    Progressivo = _ente.Progressivo,
                    RagioneSociale = _ente.RagioneSociale,
                    TipologiaEnte =_ente.TipologiaEnte
                };
            }

            return _eBL;
        }

        public int AddOne(EnteBL obj)
        {
            throw new NotImplementedException();
        }

        public int AddMany(List<EnteBL> obj)
        {
            throw new NotImplementedException();
        }

        public List<EnteBL> GetAll()
        {
            List<EnteBL> _entiBL = new List<EnteBL>();
            List<Ente> _enti = new List<Ente>();
            try 
            {
                EnteProvider provider = new EnteProvider();
                _enti = provider.GetAll(db);
                if (_enti.Any()) 
                {
                    foreach (Ente _ente in _enti)
                    {
                        EnteBL _eBL = new EnteBL
                        {
                            IdEnte = _ente.IdEnte,
                            CodAppl = _ente.CodAppl,
                            CodiceEnte = _ente.CodiceEnte,
                            CodiceFiscale = _ente.CodiceFiscale,
                            CodiceUtente = _ente.CodiceUtente,
                            ContribuzioneEnte = _ente.ContribuzioneEnte,
                            DataAggiornamento = _ente.DataAggiornamento,
                            DataFine = _ente.DataFine,
                            DataInizio = _ente.DataInizio,
                            EnteAppartenenza = _ente.EnteAppartenenza,
                            Progressivo = _ente.Progressivo,
                            RagioneSociale = _ente.RagioneSociale,
                            TipologiaEnte = _ente.TipologiaEnte
                        };
                        _entiBL.Add(_eBL);
                    }
                }
            }
            catch { }
            return _entiBL;
        }


        public int DeleteOne(EnteBL obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<EnteBL> objs)
        {
            throw new NotImplementedException();
        }
    }
}
