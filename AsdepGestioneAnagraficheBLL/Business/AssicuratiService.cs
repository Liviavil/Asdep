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
    public class AssicuratiService : IServiceAsdep<SoggettiImportatiAppoggioBL>
    {
        private AmministrazioneAsdepEntities db;
        private SoggettiImportAppoggioProvider provider = new SoggettiImportAppoggioProvider();

        public AssicuratiService()
        {
            provider = new SoggettiImportAppoggioProvider();
        }

        public List<SoggettiImportatiAppoggioBL> GetAll()
        {
            List<SoggettiImportatiAppoggioBL> lst = new List<SoggettiImportatiAppoggioBL>();
            try
            {
                using (db = new AmministrazioneAsdepEntities())
                {
                    List<SoggettiImportAppoggio> _assicuratiDal = provider.GetAll(db);
                    if (_assicuratiDal.Any())
                    {
                        foreach (SoggettiImportAppoggio _as in _assicuratiDal)
                        {
                            SoggettiImportatiAppoggioBL _asBL = new SoggettiImportatiAppoggioBL(_as);
                            lst.Add(_asBL);
                        }
                    }
                }

            }
            catch (Exception ex) { }
            return lst;
        }

        public int AddMany(List<SoggettiImportatiAppoggioBL> _assicurati)
        {
            int result = -1;
            try
            {
                List<SoggettiImportAppoggio> assToAdd = new List<SoggettiImportAppoggio>();
                if (_assicurati.Any())
                {
                    foreach (SoggettiImportatiAppoggioBL _assBL in _assicurati)
                    {
                        SoggettiImportAppoggio _sogg = new SoggettiImportAppoggio {
                            #region _sogg
                            IndirizzoResidenza = _assBL.IndirizzoResidenza,
                            CapResidenza = _assBL.CapResidenza,
                            Categoria = _assBL.Categoria,
                            CodiceFiscaleAssicurato = _assBL.CodiceFiscaleAssicurato,
                            CodiceFiscaleCapoNucleo = _assBL.CodiceFiscaleCapoNucleo,
                            Cognome = _assBL.Cognome,
                            Convenzione = _assBL.Convenzione,
                            DataCessazione = _assBL.DataCessazione,
                            DataNascitaAssicurato = _assBL.DataNascitaAssicurato,
                            Effetto = _assBL.Effetto,
                            Email = _assBL.Email,
                            Ente = _assBL.Ente,
                            EsclusioniPregresse = _assBL.EsclusioniPregresse,
                            Iban = _assBL.Iban,
                            LegameNucleo = _assBL.LegameNucleo,
                            LocalitaResidenza = _assBL.LocalitaResidenza,
                            LuogoNascitaAssicurato = _assBL.LuogoNascitaAssicurato,
                            Nome = _assBL.Nome,
                            NumeroPolizza = _assBL.NumeroPolizza,
                            SecondoNome = _assBL.SecondoNome,
                            SiglaProvResidenza = _assBL.SiglaProvResidenza,
                            Telefono = _assBL.Telefono 
                            #endregion
                        };
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

        public int AddOne(SoggettiImportatiAppoggioBL assicurato)
        {
            int result = -1;
            try
            {
                SoggettiImportAppoggio _assicurato = new SoggettiImportAppoggio
                {
                    IdSoggetto = assicurato.IdSoggetto,
                    Cognome = assicurato.Cognome,
                    Nome = assicurato.Nome,
                    CodiceFiscaleAssicurato = assicurato.CodiceFiscaleAssicurato,
                    CodiceFiscaleCapoNucleo = assicurato.CodiceFiscaleCapoNucleo,
                    Ente = assicurato.Ente,
                    LegameNucleo = assicurato.LegameNucleo,
                    Effetto = assicurato.Effetto,
                    Convenzione = assicurato.Convenzione,
                    Categoria = assicurato.Categoria,
                    NumeroPolizza = assicurato.NumeroPolizza,
                    DataCessazione = assicurato.DataCessazione,
                    LuogoNascitaAssicurato = assicurato.LuogoNascitaAssicurato
                };

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

        public List<SoggettiImportatiAppoggioBL> GetByEnte(string ente) 
        {
            List<SoggettiImportatiAppoggioBL> _soggettiBL = new List<SoggettiImportatiAppoggioBL>();
            List<SoggettiImportAppoggio> _soggettiOrigin = new List<SoggettiImportAppoggio>();

            using (db = new AmministrazioneAsdepEntities ())
            {
                _soggettiOrigin = provider.GetByEnte(db,ente);
            }

            foreach (SoggettiImportAppoggio _soggetto in _soggettiOrigin)
            {
                SoggettiImportatiAppoggioBL _soggBL = new SoggettiImportatiAppoggioBL
                {
                    #region _soggBL
                    IdSoggetto = _soggetto.IdSoggetto,
                    IndirizzoResidenza = _soggetto.IndirizzoResidenza,
                    CapResidenza = _soggetto.CapResidenza,
                    Categoria = _soggetto.Categoria,
                    CodiceFiscaleAssicurato = _soggetto.CodiceFiscaleAssicurato,
                    CodiceFiscaleCapoNucleo = _soggetto.CodiceFiscaleCapoNucleo,
                    Cognome = _soggetto.Cognome,
                    Convenzione = _soggetto.Convenzione,
                    DataCessazione = _soggetto.DataCessazione,
                    DataNascitaAssicurato = _soggetto.DataNascitaAssicurato,
                    Effetto = _soggetto.Effetto,
                    Email = _soggetto.Email,
                    Ente = _soggetto.Ente,
                    EsclusioniPregresse = _soggetto.EsclusioniPregresse,
                    Iban = _soggetto.Iban,
                    LegameNucleo = _soggetto.LegameNucleo,
                    LocalitaResidenza = _soggetto.LocalitaResidenza,
                    LuogoNascitaAssicurato = _soggetto.LuogoNascitaAssicurato,
                    Nome = _soggetto.Nome,
                    NumeroPolizza = _soggetto.NumeroPolizza,
                    SecondoNome = _soggetto.SecondoNome,
                    SiglaProvResidenza = _soggetto.SiglaProvResidenza,
                    Telefono = _soggetto.Telefono 
                    #endregion
                };
                _soggettiBL.Add(_soggBL);
            }

            return _soggettiBL;
        }
    }
}
