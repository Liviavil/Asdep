using AmministrazioneAsdep;
using AmministrazioneAsdep.DAL;
using Asdep.Common.DAO;
using AsdepGestioneAnagraficheBLL.Extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Business
{
    public class AdesioneService : IServiceAsdep<AdesioneDao>
    {
        AmministrazioneAsdep.AmministrazioneAsdepEntities db;
        AdesioniProvider provider;
        public AdesioneService()
        {
            provider = new AdesioniProvider();
        }

        public int AddOne(AdesioneDao dao)
        {
            Adesione _ad = new Adesione();
            Asdep.Common.DAO.ExtraDao.PropertyCopier<AdesioneDao, Adesione>.Copy(dao, _ad);
            Soggetto Soggetto = new Soggetto();
            Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggettoDao, Soggetto>.Copy(dao.Soggetto, Soggetto);
            _ad.Soggetto = Soggetto;
            Soggetto Soggetto1 = new Soggetto();
            Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggettoDao, Soggetto>.Copy(dao.Soggetto1, Soggetto1);
            _ad.Soggetto1 = Soggetto1;

            using (db= new AmministrazioneAsdepEntities ())
            {
                return provider.AddOne(db, _ad);
            }
        }

        public int AddMany(List<AdesioneDao> obj)
        {
            throw new NotImplementedException();
        }

        public List<AdesioneDao> GetAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(AdesioneDao obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<AdesioneDao> objs)
        {
            throw new NotImplementedException();
        }

        public List<AdesioneDao> RicercaAdesioni()
        {
            List<AdesioneDao> adesioniDao = new List<AdesioneDao>();
            List<Adesione> _adesioni = new List<Adesione>();
            using (db = new AmministrazioneAsdep.AmministrazioneAsdepEntities())
            {
                _adesioni = provider.RicercaAdesione(db);
                foreach (Adesione _ad in _adesioni)
                {
                    AdesioneDao _dao = new AdesioneDao();
                    _dao.Eta = Helper.CalculateAge(_ad.Soggetto.DataNascita);
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<Adesione, AdesioneDao>.Copy(_ad, _dao);
                    EnteDao EnteDao = new EnteDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<Ente, EnteDao>.Copy(_ad.Ente, EnteDao);
                    _dao.Ente = EnteDao;
                    SoggettoDao Soggetto = new SoggettoDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<Soggetto, SoggettoDao>.Copy(_ad.Soggetto, Soggetto);
                    _dao.Soggetto = Soggetto;
                    SoggettoDao Soggetto1 = new SoggettoDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<Soggetto, SoggettoDao>.Copy(_ad.Soggetto1, Soggetto1);
                    _dao.Soggetto1 = Soggetto1;
                    T_StatoAdesioneDao T_StatoAdesione = new T_StatoAdesioneDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_StatoAdesione, T_StatoAdesioneDao>.Copy(_ad.T_StatoAdesione, T_StatoAdesione);
                    _dao.T_StatoAdesione = T_StatoAdesione;
                    T_TipiLegameDao T_TipiLegame = new T_TipiLegameDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipiLegame, T_TipiLegameDao>.Copy(_ad.T_TipiLegame, T_TipiLegame);
                    _dao.T_TipiLegame = T_TipiLegame;
                    T_TipoAdesioneDao T_TipoAdesione = new T_TipoAdesioneDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipoAdesione, T_TipoAdesioneDao>.Copy(_ad.T_TipoAdesione, T_TipoAdesione);
                    _dao.T_TipoAdesione = T_TipoAdesione;
                    T_TipoSoggettoDao T_TipoSoggetto = new T_TipoSoggettoDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipoSoggetto, T_TipoSoggettoDao>.Copy(_ad.T_TipoSoggetto, T_TipoSoggetto);
                    _dao.T_TipoSoggetto = T_TipoSoggetto;
                    _dao.ErroriList = new List<T_ErroriIODao>();
                    
                    adesioniDao.Add(_dao);
                }
            }


            return adesioniDao;
        }

        public AdesioneDao SelectById(long id)
        {
            Adesione _ad = new Adesione();
            AdesioneDao _dao = new AdesioneDao();
            using (db= new AmministrazioneAsdepEntities ())
            {
                _ad= provider.SelectById(db, id);
                _dao.Eta = Helper.CalculateAge(_ad.Soggetto.DataNascita);
                Asdep.Common.DAO.ExtraDao.PropertyCopier<Adesione, AdesioneDao>.Copy(_ad, _dao);
                EnteDao EnteDao = new EnteDao();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<Ente, EnteDao>.Copy(_ad.Ente, EnteDao);
                _dao.Ente = EnteDao;
                SoggettoDao Soggetto = new SoggettoDao();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<Soggetto, SoggettoDao>.Copy(_ad.Soggetto, Soggetto);
                _dao.Soggetto = Soggetto;
                SoggettoDao Soggetto1 = new SoggettoDao();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<Soggetto, SoggettoDao>.Copy(_ad.Soggetto1, Soggetto1);
                _dao.Soggetto1 = Soggetto1;
                T_StatoAdesioneDao T_StatoAdesione = new T_StatoAdesioneDao();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<T_StatoAdesione, T_StatoAdesioneDao>.Copy(_ad.T_StatoAdesione, T_StatoAdesione);
                _dao.T_StatoAdesione = T_StatoAdesione;
                T_TipiLegameDao T_TipiLegame = new T_TipiLegameDao();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipiLegame, T_TipiLegameDao>.Copy(_ad.T_TipiLegame, T_TipiLegame);
                _dao.T_TipiLegame = T_TipiLegame;
                T_TipoAdesioneDao T_TipoAdesione = new T_TipoAdesioneDao();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipoAdesione, T_TipoAdesioneDao>.Copy(_ad.T_TipoAdesione, T_TipoAdesione);
                _dao.T_TipoAdesione = T_TipoAdesione;
                T_TipoSoggettoDao T_TipoSoggetto = new T_TipoSoggettoDao();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipoSoggetto, T_TipoSoggettoDao>.Copy(_ad.T_TipoSoggetto, T_TipoSoggetto);
                _dao.T_TipoSoggetto = T_TipoSoggetto;
                _dao.ErroriList = new List<T_ErroriIODao>();
            }
            return _dao;
        }

        public List<AdesioneDao> SelectByIdCapoNucleo(long id)
        {
            List<AdesioneDao> _daos = new List<AdesioneDao>();
            List<Adesione> _ads = new List<Adesione>();
            
            using (db = new AmministrazioneAsdepEntities())
            {
                _ads = provider.SelectByIdCapoNucleo(db, id);
                foreach (Adesione _ad in _ads)
                {
                    AdesioneDao _dao = new AdesioneDao();
                    _dao.Eta = Helper.CalculateAge(_ad.Soggetto.DataNascita);
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<Adesione, AdesioneDao>.Copy(_ad, _dao);
                    EnteDao EnteDao = new EnteDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<Ente, EnteDao>.Copy(_ad.Ente, EnteDao);
                    _dao.Ente = EnteDao;
                    SoggettoDao Soggetto = new SoggettoDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<Soggetto, SoggettoDao>.Copy(_ad.Soggetto, Soggetto);
                    _dao.Soggetto = Soggetto;
                    SoggettoDao Soggetto1 = new SoggettoDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<Soggetto, SoggettoDao>.Copy(_ad.Soggetto1, Soggetto1);
                    _dao.Soggetto1 = Soggetto1;
                    T_StatoAdesioneDao T_StatoAdesione = new T_StatoAdesioneDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_StatoAdesione, T_StatoAdesioneDao>.Copy(_ad.T_StatoAdesione, T_StatoAdesione);
                    _dao.T_StatoAdesione = T_StatoAdesione;
                    T_TipiLegameDao T_TipiLegame = new T_TipiLegameDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipiLegame, T_TipiLegameDao>.Copy(_ad.T_TipiLegame, T_TipiLegame);
                    _dao.T_TipiLegame = T_TipiLegame;
                    T_TipoAdesioneDao T_TipoAdesione = new T_TipoAdesioneDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipoAdesione, T_TipoAdesioneDao>.Copy(_ad.T_TipoAdesione, T_TipoAdesione);
                    _dao.T_TipoAdesione = T_TipoAdesione;
                    T_TipoSoggettoDao T_TipoSoggetto = new T_TipoSoggettoDao();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<T_TipoSoggetto, T_TipoSoggettoDao>.Copy(_ad.T_TipoSoggetto, T_TipoSoggetto);
                    _dao.T_TipoSoggetto = T_TipoSoggetto;
                    _daos.Add(_dao);
                }

            }
            return _daos;
        }

        public AdesioneDao ModificaAdesione(long id)
        {
            Adesione _ad = new Adesione();
            AdesioneDao _dao = new AdesioneDao();
            AdesioneDao _daoValido = new AdesioneDao();
            _dao = SelectById(id);
            ErroriIOService service = new ErroriIOService();
            _dao.ErroriList = service.ValidaAdesioneCollettiva(_dao);
            return _dao;
        }

        public int SalvaAdesione(AdesioneDao dao)
        {
            Adesione _ad = new Adesione();
            Asdep.Common.DAO.ExtraDao.PropertyCopier<AdesioneDao, Adesione>.Copy(dao, _ad);
            Soggetto Soggetto = new Soggetto();
            Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggettoDao, Soggetto>.Copy(dao.Soggetto, Soggetto);
            _ad.Soggetto = Soggetto;
            Soggetto Soggetto1 = new Soggetto();
            Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggettoDao, Soggetto>.Copy(dao.Soggetto1, Soggetto1);
            _ad.Soggetto1 = Soggetto1;

            using (db=new AmministrazioneAsdepEntities ())
            {
                return provider.SalvaAdesioneCollettiva(db, _ad);
            }
        }

        public int CessazioneAdesione(AdesioneDao dao) 
        {
            int result = -1;
            if (dao.CodLegame.Equals("001"))
            {
                List<AdesioneDao> adesioniNucleo = SelectByIdCapoNucleo(dao.IdSoggetto);
                foreach (AdesioneDao _dao in adesioniNucleo)
                {
                    using (db = new AmministrazioneAsdepEntities())
                    {
                        Adesione _ad = new Adesione();
                        Asdep.Common.DAO.ExtraDao.PropertyCopier<AdesioneDao, Adesione>.Copy(_dao, _ad);
                        result = provider.CessazioneAdesioneCollettiva(db, _ad);
                    }
                }
            }
            else 
            {
                using (db = new AmministrazioneAsdepEntities())
                {
                    Adesione _ad = new Adesione();
                    Asdep.Common.DAO.ExtraDao.PropertyCopier<AdesioneDao, Adesione>.Copy(dao, _ad);
                    result = provider.CessazioneAdesioneCollettiva(db, _ad);
                }
            }
            return result;
        }
    }
}
