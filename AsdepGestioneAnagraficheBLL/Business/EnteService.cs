using AmministrazioneAsdep;
using AmministrazioneAsdep.DAL;
using Asdep.Common.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Business
{
    public class EnteService : IServiceAsdep<EnteDao>
    {
        private AmministrazioneAsdepEntities db;

        public EnteService()
        {
            db = new AmministrazioneAsdepEntities();
        }
        public EnteDao SelectByCodiceEnte(string name)
        {
            Ente _ente = new Ente();
            EnteDao _eBL = null;
            using (db)
            {
                EnteProvider provider = new EnteProvider();
                _ente = provider.SelectByEnte(db, name);
            }

            if (_ente != null)
            {
                #region comment
                //_eBL = new EnteDao
                //{
                //    CodAppl = _ente.CodAppl,
                //    CodiceEnte = _ente.CodiceEnte,
                //    CodiceFiscale = _ente.CodiceFiscale,
                //    CodiceUtente = _ente.CodiceUtente,
                //    ContribuzioneEnte = _ente.ContribuzioneEnte,
                //    DataAggiornamento = _ente.DataAggiornamento,
                //    DataFine = _ente.DataFine,
                //    DataInizio = _ente.DataInizio,
                //    EnteAppartenenza = _ente.EnteAppartenenza,
                //    Progressivo = _ente.Progressivo,
                //    RagioneSociale = _ente.RagioneSociale,
                //    TipologiaEnte =_ente.TipologiaEnte
                //}; 
                #endregion
                _eBL = new EnteDao();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<Ente, EnteDao>.Copy(_ente, _eBL);
            }

            return _eBL;
        }

        public int AddOne(EnteDao obj)
        {
            throw new NotImplementedException();
        }

        public int AddMany(List<EnteDao> obj)
        {
            throw new NotImplementedException();
        }

        public List<EnteDao> GetAll()
        {
            List<EnteDao> _entiBL = new List<EnteDao>();
            List<Ente> _enti = new List<Ente>();
            try
            {
                EnteProvider provider = new EnteProvider();
                _enti = provider.GetAll(db);
                if (_enti.Any())
                {
                    foreach (Ente _ente in _enti)
                    {
                        #region comment
                        //EnteDao _eBL = new EnteDao
                        //{
                        //    IdEnte = _ente.IdEnte,
                        //    CodAppl = _ente.CodAppl,
                        //    CodiceEnte = _ente.CodiceEnte,
                        //    CodiceFiscale = _ente.CodiceFiscale,
                        //    CodiceUtente = _ente.CodiceUtente,
                        //    ContribuzioneEnte = _ente.ContribuzioneEnte,
                        //    DataAggiornamento = _ente.DataAggiornamento,
                        //    DataFine = _ente.DataFine,
                        //    DataInizio = _ente.DataInizio,
                        //    EnteAppartenenza = _ente.EnteAppartenenza,
                        //    Progressivo = _ente.Progressivo,
                        //    RagioneSociale = _ente.RagioneSociale,
                        //    TipologiaEnte = _ente.TipologiaEnte
                        //}; 
                        #endregion

                        EnteDao _eBL = new EnteDao();
                        Asdep.Common.DAO.ExtraDao.PropertyCopier<Ente, EnteDao>.Copy(_ente, _eBL);
                        _entiBL.Add(_eBL);
                    }
                }
            }
            catch { }
            return _entiBL;
        }

        public List<string> GetAllEntiInLavorazione()
        {
            List<string> _entiToSend = new List<string>();
            
            using (db)
            {
                EnteProvider _provider = new EnteProvider();
                _entiToSend = _provider.GetEntiInLavorazione(db);
            }
            
            return _entiToSend;
        }


        public int DeleteOne(EnteDao obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<EnteDao> objs)
        {
            throw new NotImplementedException();
        }
    }
}
