using AsdepGestioneAnagraficheBLL;
using AsdepGestioneAnagraficheBLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.DAL;
using AmministrazioneAsdep;
using AsdepGestioneAnagraficheBLL.Business;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class AsdepWcf : IAsdepWcf
    {

        bool IAsdepWcf.CancellaAnagrafica()
        {
            throw new NotImplementedException();
        }


        bool IAsdepWcf.ValidaAnagrafica()
        {
            throw new NotImplementedException();
        }

        Anagrafica IAsdepWcf.GetAnagrafica()
        {
            throw new NotImplementedException();
        }


        public int CaricaAnagrafica(Anagrafica anagrafica)
        {
            throw new NotImplementedException();
        }


        public Anagrafica GetSoggettiImportAnagrafica()
        {
            throw new NotImplementedException();
        }

        public int InsertSoggettoAppoggio(Anagrafica anagrafica)
        {
            int result = -1;
            try
            {

            }
            catch (Exception ex) { }
            return result;
        }


        public int InsertSoggettiAppoggio(List<Anagrafica> anagrafiche)
        {
            int result = -1;
            try
            {
                List<SoggettiImportatiAppoggioBL> soggetti = new List<SoggettiImportatiAppoggioBL>();
                if (anagrafiche.Any())
                {
                    foreach (Anagrafica an in anagrafiche)
                    {
                        SoggettiImportatiAppoggioBL soggettoAppoggio = new SoggettiImportatiAppoggioBL
                        {
                            CapResidenza = an.CapResidenza,
                            Categoria = an.Categoria,
                            CodiceFiscaleAssicurato = an.CodiceFiscaleAssicurato,
                            CodiceFiscaleCapoNucleo = an.CodiceFiscaleCapoNucleo,
                            Cognome = an.Cognome,
                            Convenzione = an.Convenzione,
                            DataCessazione = an.DataCessazione,
                            DataNascitaAssicurato = an.DataNascitaAssicurato,
                            Effetto = an.Effetto,
                            Email = an.Email,
                            Ente = an.Ente,
                            EsclusioniPregresse = an.Esclusioni,
                            Iban = an.Iban,
                            IndirizzoResidenza = an.IndirizzoResidenza,
                            LegameNucleo = an.LegameNucleo,
                            LocalitaResidenza = an.LocalitaResidenza,
                            LuogoNascitaAssicurato = an.LuogoNascitaAssicurato,
                            Nome = an.Nome,
                            NumeroPolizza = an.NumeroPolizza,
                            SecondoNome = an.SecondoNome,
                            SiglaProvResidenza = an.SiglaProvResidenza,
                            Telefono = an.Telefono
                        };
                        soggetti.Add(soggettoAppoggio);
                    }
                }
                IServiceAsdep<SoggettiImportatiAppoggioBL> interfaceService = new AssicuratiService();
                result = interfaceService.AddMany(soggetti);
            }
            catch (Exception ex) { }
            return result;
        }


        public List<DAL.Ente> GetAllEnti()
        {
            List<DAL.Ente> _enti = new List<DAL.Ente>();
            List<EnteBL> _entiBL = new List<EnteBL>();
            try
            {
                IServiceAsdep<EnteBL> _service = new EnteService();
                _entiBL = _service.GetAll();

                foreach (EnteBL _ente in _entiBL)
                {
                    WcfService.DAL.Ente _e = new DAL.Ente 
                    {
                        IdEnte = _ente.IdEnte,
                        CodAppl = _ente.CodAppl,
                        CodiceEnte = _ente.CodiceEnte,
                        CodiceFiscale = _ente.CodiceFiscale,
                        CodiceUtente = _ente.CodiceUtente,
                        ContribuzioneEnte = null,
                        DataAggiornamento = _ente.DataAggiornamento,
                        DataFine = _ente.DataFine,
                        DataInizio = _ente.DataInizio,
                        EnteAppartenenza = null,
                        Progressivo = _ente.Progressivo,
                        RagioneSociale = _ente.RagioneSociale,
                        TipologiaEnte = null
                    };
                    _enti.Add(_e);
                }
            }
            catch (Exception ex) { }
            return _enti;
        }
    }
}
