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

        public AssicuratiService()
        {
            db = new AmministrazioneAsdepEntities();
        }

        public List<SoggettiImportatiAppoggioBL> GetAll()
        {
            List<SoggettiImportatiAppoggioBL> lst = new List<SoggettiImportatiAppoggioBL>();
            try
            {
                using (db)
                {
                    List<SoggettiImportAppoggio> _assicuratiDal = SoggettiImportAppoggioProvider.GetAllAssicurati(db);
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
                        };
                        assToAdd.Add(_sogg);
                    }
                }
                using (db)
                {

                    result = SoggettiImportAppoggioProvider.AddAssicurati(db, assToAdd);
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

                using (db)
                {
                    result = SoggettiImportAppoggioProvider.AddAssicurato(db, _assicurato);
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }
    }
}
