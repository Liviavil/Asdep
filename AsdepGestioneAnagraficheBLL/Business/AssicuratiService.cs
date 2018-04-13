using AmministrazioneAsdep;
using AmministrazioneAsdep.DAL;
using AsdepGestioneAnagraficheBLL.Extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Asdep.Common.DAO;
using Asdep.Common.DAO.ExtraDao;


namespace AsdepGestioneAnagraficheBLL.Business
{
    public class AssicuratiService : IServiceAsdep<SoggettiImportAppoggioDao>
    {
        private AmministrazioneAsdepEntities db;
        private SoggettiImportAppoggioProvider provider = new SoggettiImportAppoggioProvider();

        public AssicuratiService()
        {
            provider = new SoggettiImportAppoggioProvider();
        }

        #region CRUD
        public List<SoggettiImportAppoggioDao> GetAll()
        {
            List<SoggettiImportAppoggioDao> lst = new List<SoggettiImportAppoggioDao>();
            try
            {
                using (db = new AmministrazioneAsdepEntities())
                {
                    List<SoggettiImportAppoggio> _assicuratiDal = provider.GetAll(db);
                    if (_assicuratiDal.Any())
                    {
                        foreach (SoggettiImportAppoggio _as in _assicuratiDal)
                        {
                            SoggettiImportAppoggioDao _asBL = new SoggettiImportAppoggioDao();
                            Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggettiImportAppoggio, SoggettiImportAppoggioDao>.Copy(_as, _asBL);
                            lst.Add(_asBL);
                        }
                    }
                }

            }
            catch (Exception ex) { }
            return lst;
        }

        public int AddMany(List<SoggettiImportAppoggioDao> _assicurati)
        {
            int result = -1;
            try
            {
                List<SoggettiImportAppoggio> assToAdd = new List<SoggettiImportAppoggio>();
                if (_assicurati.Any())
                {
                    foreach (SoggettiImportAppoggioDao _assBL in _assicurati)
                    {
                        #region comment
                        //SoggettiImportAppoggio _sogg = new SoggettiImportAppoggio {
                        //    #region _sogg
                        //    IndirizzoResidenza = _assBL.IndirizzoResidenza,
                        //    CapResidenza = _assBL.CapResidenza,
                        //    Categoria = _assBL.Categoria,
                        //    CodiceFiscaleAssicurato = _assBL.CodiceFiscaleAssicurato,
                        //    CodiceFiscaleCapoNucleo = _assBL.CodiceFiscaleCapoNucleo,
                        //    Cognome = _assBL.Cognome,
                        //    Convenzione = _assBL.Convenzione,
                        //    DataCessazione = _assBL.DataCessazione,
                        //    DataNascitaAssicurato = _assBL.DataNascitaAssicurato,
                        //    Effetto = _assBL.Effetto,
                        //    Email = _assBL.Email,
                        //    Ente = _assBL.Ente,
                        //    EsclusioniPregresse = _assBL.EsclusioniPregresse,
                        //    Iban = _assBL.Iban,
                        //    LegameNucleo = _assBL.LegameNucleo,
                        //    LocalitaResidenza = _assBL.LocalitaResidenza,
                        //    LuogoNascitaAssicurato = _assBL.LuogoNascitaAssicurato,
                        //    Nome = _assBL.Nome,
                        //    NumeroPolizza = _assBL.NumeroPolizza,
                        //    SecondoNome = _assBL.SecondoNome,
                        //    SiglaProvResidenza = _assBL.SiglaProvResidenza,
                        //    Telefono = _assBL.Telefono 
                        //    #endregion
                        //}; 
                        #endregion
                        SoggettiImportAppoggio _sogg = new SoggettiImportAppoggio();
                        Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggettiImportAppoggioDao, SoggettiImportAppoggio>.Copy(_assBL, _sogg);
                        assToAdd.Add(_sogg);
                    }
                }
                using (db = new AmministrazioneAsdepEntities())
                {

                    result = provider.AddMany(db, assToAdd);
                }
            }
            catch (Exception ex) { result = -1; }
            return result;
        }

        public int AddOne(SoggettiImportAppoggioDao assicurato)
        {
            int result = -1;
            try
            {
                #region comment
                //SoggettiImportAppoggio _assicurato = new SoggettiImportAppoggio
                //{
                //    IdSoggetto = assicurato.IdSoggetto,
                //    Cognome = assicurato.Cognome,
                //    Nome = assicurato.Nome,
                //    CodiceFiscaleAssicurato = assicurato.CodiceFiscaleAssicurato,
                //    CodiceFiscaleCapoNucleo = assicurato.CodiceFiscaleCapoNucleo,
                //    Ente = assicurato.Ente,
                //    LegameNucleo = assicurato.LegameNucleo,
                //    Effetto = assicurato.Effetto,
                //    Convenzione = assicurato.Convenzione,
                //    Categoria = assicurato.Categoria,
                //    NumeroPolizza = assicurato.NumeroPolizza,
                //    DataCessazione = assicurato.DataCessazione,
                //    LuogoNascitaAssicurato = assicurato.LuogoNascitaAssicurato
                //}; 
                #endregion

                SoggettiImportAppoggio _assicurato = new SoggettiImportAppoggio();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggettiImportAppoggioDao, SoggettiImportAppoggio>.Copy(assicurato, _assicurato);

                using (db = new AmministrazioneAsdepEntities())
                {
                    result = provider.AddOne(db, _assicurato);
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public List<SoggettiImportAppoggioDao> GetByEnte(string ente)
        {
            List<SoggettiImportAppoggioDao> _soggettiBL = new List<SoggettiImportAppoggioDao>();
            List<SoggettiImportAppoggio> _soggettiOrigin = new List<SoggettiImportAppoggio>();
            //List<SoggettiImportAppoggioDao> _soggettiBLValidi = new List<SoggettiImportAppoggioDao>();

            using (db = new AmministrazioneAsdepEntities())
            {
                _soggettiOrigin = provider.GetByEnte(db, ente);
            }

            foreach (SoggettiImportAppoggio _soggetto in _soggettiOrigin)
            {
                #region comment
                //SoggettiImportAppoggioDao _soggBL = new SoggettiImportAppoggioDao
                //{
                //    #region _soggBL
                //    IdSoggetto = _soggetto.IdSoggetto,
                //    IndirizzoResidenza = _soggetto.IndirizzoResidenza,
                //    CapResidenza = _soggetto.CapResidenza,
                //    Categoria = _soggetto.Categoria,
                //    CodiceFiscaleAssicurato = _soggetto.CodiceFiscaleAssicurato,
                //    CodiceFiscaleCapoNucleo = _soggetto.CodiceFiscaleCapoNucleo,
                //    Cognome = _soggetto.Cognome,
                //    Convenzione = _soggetto.Convenzione,
                //    DataCessazione = _soggetto.DataCessazione,
                //    DataNascitaAssicurato = _soggetto.DataNascitaAssicurato,
                //    Effetto = _soggetto.Effetto,
                //    Email = _soggetto.Email,
                //    Ente = _soggetto.Ente,
                //    EsclusioniPregresse = _soggetto.EsclusioniPregresse,
                //    Iban = _soggetto.Iban,
                //    LegameNucleo = _soggetto.LegameNucleo,
                //    LocalitaResidenza = _soggetto.LocalitaResidenza,
                //    LuogoNascitaAssicurato = _soggetto.LuogoNascitaAssicurato,
                //    Nome = _soggetto.Nome,
                //    NumeroPolizza = _soggetto.NumeroPolizza,
                //    SecondoNome = _soggetto.SecondoNome,
                //    SiglaProvResidenza = _soggetto.SiglaProvResidenza,
                //    Telefono = _soggetto.Telefono
                //    #endregion
                //}; 
                #endregion

                SoggettiImportAppoggioDao _soggBL = new SoggettiImportAppoggioDao();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggettiImportAppoggio, SoggettiImportAppoggioDao>.Copy(_soggetto, _soggBL);

                _soggBL.Errori = new List<ErroreDao>();//ValidaAdesioneCollettiva(_soggBL).Where(x => x.Exist == true).ToList();

                _soggettiBL.Add(_soggBL);
            }

            return _soggettiBL;
        }

        public int DeleteOne(SoggettiImportAppoggioDao assicurato)
        {
            int result = -1;
            try
            {
                #region Comment
                //SoggettiImportAppoggio _assicurato = new SoggettiImportAppoggio
                //{
                //    IdSoggetto = assicurato.IdSoggetto,
                //    Cognome = assicurato.Cognome,
                //    Nome = assicurato.Nome,
                //    CodiceFiscaleAssicurato = assicurato.CodiceFiscaleAssicurato,
                //    CodiceFiscaleCapoNucleo = assicurato.CodiceFiscaleCapoNucleo,
                //    Ente = assicurato.Ente,
                //    LegameNucleo = assicurato.LegameNucleo,
                //    Effetto = assicurato.Effetto,
                //    Convenzione = assicurato.Convenzione,
                //    Categoria = assicurato.Categoria,
                //    NumeroPolizza = assicurato.NumeroPolizza,
                //    DataCessazione = assicurato.DataCessazione,
                //    LuogoNascitaAssicurato = assicurato.LuogoNascitaAssicurato
                //}; 
                #endregion

                SoggettiImportAppoggio _assicurato = new SoggettiImportAppoggio();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggettiImportAppoggioDao, SoggettiImportAppoggio>.Copy(assicurato, _assicurato);

                using (db = new AmministrazioneAsdepEntities())
                {
                    result = provider.DeleteOne(db, _assicurato);
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }

        public int DeleteMany(List<SoggettiImportAppoggioDao> objs)
        {
            int result = -1;
            List<SoggettiImportAppoggio> _soggettiOrigin = new List<SoggettiImportAppoggio>();

            foreach (SoggettiImportAppoggioDao _soggetto in objs)
            {
                #region Comment
                //SoggettiImportAppoggio _soggBL = new SoggettiImportAppoggio
                //{
                //    #region _soggBL
                //    IdSoggetto = _soggetto.IdSoggetto,
                //    IndirizzoResidenza = _soggetto.IndirizzoResidenza,
                //    CapResidenza = _soggetto.CapResidenza,
                //    Categoria = _soggetto.Categoria,
                //    CodiceFiscaleAssicurato = _soggetto.CodiceFiscaleAssicurato,
                //    CodiceFiscaleCapoNucleo = _soggetto.CodiceFiscaleCapoNucleo,
                //    Cognome = _soggetto.Cognome,
                //    Convenzione = _soggetto.Convenzione,
                //    DataCessazione = _soggetto.DataCessazione,
                //    DataNascitaAssicurato = _soggetto.DataNascitaAssicurato,
                //    Effetto = _soggetto.Effetto,
                //    Email = _soggetto.Email,
                //    Ente = _soggetto.Ente,
                //    EsclusioniPregresse = _soggetto.EsclusioniPregresse,
                //    Iban = _soggetto.Iban,
                //    LegameNucleo = _soggetto.LegameNucleo,
                //    LocalitaResidenza = _soggetto.LocalitaResidenza,
                //    LuogoNascitaAssicurato = _soggetto.LuogoNascitaAssicurato,
                //    Nome = _soggetto.Nome,
                //    NumeroPolizza = _soggetto.NumeroPolizza,
                //    SecondoNome = _soggetto.SecondoNome,
                //    SiglaProvResidenza = _soggetto.SiglaProvResidenza,
                //    Telefono = _soggetto.Telefono
                //    #endregion
                //}; 
                #endregion
                SoggettiImportAppoggio _soggBL = new SoggettiImportAppoggio();
                Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggettiImportAppoggioDao, SoggettiImportAppoggio>.Copy(_soggetto, _soggBL);
                _soggettiOrigin.Add(_soggBL);
            }
            using (db = new AmministrazioneAsdepEntities())
            {
                result = provider.DeleteMany(db, _soggettiOrigin);
            }

            return result;
        }

        public int DeleteByEnte(string ente)
        {
            int result = -1;
            using (db = new AmministrazioneAsdepEntities())
            {
                result = provider.DeleteByEnte(db, ente);
            }

            return result;
        }
        #endregion


        public List<ErroreDao> ValidaAdesioneCollettiva(SoggettiImportAppoggioDao sogg)
        {
            List<ErroreDao> errori = new List<ErroreDao>();

            IValida _validazione = new ValidaIban();
            errori.Add(_validazione.Esegui(sogg));
            _validazione = new ValidaEnte();
            errori.Add(_validazione.Esegui(sogg));

            return errori;
            #region old
            //List<ErroreDao> errori = new List<ErroreDao>();
            //const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

            //var objFieldNames = typeof(SoggettiImportAppoggioDao).GetProperties(flags).Cast<PropertyInfo>().
            //   Select(item => new
            //   {
            //       Name = item.Name,
            //       Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
            //   }).ToList();

            //errori = new List<ErroreDao>();
            //foreach (var obj in objFieldNames)
            //{
            //    ErroreDao errore = new ErroreDao();
            //    errore = Helper.Check(obj.Name, sogg);
            //    errori.Add(errore);
            //}

            //return errori; 
            #endregion
        }
    }
}
