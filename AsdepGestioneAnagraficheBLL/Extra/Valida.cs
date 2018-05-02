using Asdep.Common.DAO;
using Asdep.Common.DAO.ExtraDao;
using AsdepGestioneAnagraficheBLL.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Extra
{
    public class Valida
    {
        private T_ErroriIODao _errore;

        public T_ErroriIODao Errore
        {
            get { return _errore; }
            set { _errore = value; }
        }

        public Valida()
        {
            Errore = new T_ErroriIODao();
        }
    }

    public class ValidaEmail : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            bool validemail = new EmailAddressAttribute().IsValid(valore);
            if (!validemail)
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("005");

            }
            return Errore;
        }
    }

    public class ValidaNome : Valida, IValida 
    {

        public T_ErroriIODao Esegui(string codiceFiscale, string valore)
        {
            try 
            {
                if (string.IsNullOrEmpty(valore)) 
                {
                    ErroriIOService _service = new ErroriIOService();
                    Errore = _service.GetById("019");
                    return Errore;
                }
                if (!string.IsNullOrEmpty(codiceFiscale) ) 
                {
                    string nomeCF = codiceFiscale.Substring(3, 3);
                    string calcolato = CodiceFiscale.CalcolaCodiceNome(valore);
                    if (!nomeCF.Equals(calcolato)) 
                    {
                        ErroriIOService _service = new ErroriIOService();
                        Errore = _service.GetById("015");
                        return Errore;
                    }
                }
            }
            catch { }
            return Errore;
        }

        public T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }

    public class ValidaCognome : Valida, IValida
    {
        public T_ErroriIODao Esegui(string codiceFiscale, string cognome) 
        {
            try
            {
                if (string.IsNullOrEmpty(cognome))
                {
                    ErroriIOService _service = new ErroriIOService();
                    Errore = _service.GetById("020");
                    return Errore;
                }
                if (!string.IsNullOrEmpty(codiceFiscale))
                {
                    string cognomeCF = codiceFiscale.Substring(0, 3);
                    string calcolato = CodiceFiscale.CalcolaCodiceCognome(cognome);
                    if (!cognomeCF.Equals(calcolato))
                    {
                        ErroriIOService _service = new ErroriIOService();
                        Errore = _service.GetById("016");
                        return Errore;
                    }
                }
            }
            catch { }
            return Errore;
        }

        public T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }

    public class ValidaDataCessazione : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            if (string.IsNullOrEmpty(valore)) 
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("024");
            }
            return Errore;
        }
    }

    public class ValidaTelefono : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }

    public class ValidaIban : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            if (string.IsNullOrEmpty(valore)) 
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("007");
                return Errore;
            }
            if (!Helper.ValidateBankAccount(valore)) 
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("006");
                return Errore;
            }
            return Errore;
            
        }
    }

    public class ValidaCapResid : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaCongruenzaPolizza : Valida, IValida 
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string adesione, string ente)
        {
            T_TipoAdesioneService service = new T_TipoAdesioneService();
            if (service.CongruenzaEntePolizza(adesione, ente))
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("025");
            }

            return Errore;
        }

        public T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaSiglaProv : Valida, IValida
    {
        public T_ErroriIODao Esegui(string valore)
        {
            if (string.IsNullOrEmpty(valore))
            {
                ErroriIOService _serviceE = new ErroriIOService();
                Errore = _serviceE.GetById("018");
            }
            ComuniService _service = new ComuniService();

            if (!_service.FindSiglaProvincia(valore))
            {
                ErroriIOService _serviceE = new ErroriIOService();
                Errore = _serviceE.GetById("026");
            }
            
            return Errore;
        }
    }
    public class ValidaLocResid : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaIndirizzoResid : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }

    public class ValidaEffetto : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(DateTime? valore, string ente)
        {
            try 
            {
                if (string.IsNullOrEmpty(valore.ToString())) 
                {
                    ErroriIOService _service = new ErroriIOService();
                    Errore = _service.GetById("021");
                    return Errore;
                }
                if (!Helper.CheckDataEffettoDataContrEnte(valore, ente))
                {
                    ErroriIOService _service = new ErroriIOService();
                    Errore = _service.GetById("022");
                    return Errore;
                }
            }
            catch { }
            return Errore;
        }

        public T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaLegame : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            T_TipoLegameService _eService = new T_TipoLegameService();
            T_TipiLegameDao legameBL = _eService.GetByCodLegame(valore);
            if (legameBL.CodLegameImport == null)
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("008");
            }
            return Errore;
        }
    }

    public class ValidaDataNascita : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string codiceFiscale, DateTime? valore)
        {
            try
            {
                if (!string.IsNullOrEmpty(valore.ToString()))
                {

                    if (!string.IsNullOrEmpty(codiceFiscale))
                    {
                        string calcolato = CodiceFiscale.GetDateFromFiscalCode(codiceFiscale);
                        if (!valore.Equals(calcolato))
                        {
                            ErroriIOService _service = new ErroriIOService();
                            Errore = _service.GetById("017");
                            return Errore;
                        }
                    }
                }
            }
            catch { }
            return Errore;
        }

        public T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaLuogoNascita : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaCFCapoNucleo : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            if (string.IsNullOrEmpty(valore)) 
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("014");
                return Errore;
            }
            if (!Extra.CodiceFiscale.ControlloFormaleOK(valore))
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("009");
                return Errore;
            }
            return Errore;
        }
    }
    public class ValidaCategoria : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            if (!valore.ToLower().Equals("dipendenti"))
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("010");
            }
            return Errore;
        }
    }

    public class ValidaConvenzione : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaPolizza : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            if (!(valore.ToLower().Equals("base_integrativa") || valore.ToLower().Equals("base")))
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("011");
            }
            return Errore;
        }
    }
    public class ValidaCFAssic : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            if (string.IsNullOrEmpty(valore))
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("013");
                return Errore;
            }
            if (!Extra.CodiceFiscale.ControlloFormaleOK(valore))
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("012");
                return Errore;
            }
            return Errore;
        }
    }
    public class ValidaEnte : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            EnteService _eService = new EnteService();
            EnteDao enteBL = _eService.SelectByCodiceEnte(valore);
            if (enteBL.CodiceEnte == null)
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("003");
            }
            return Errore;
        }
    }
    public class ValidaEsclusioni : Valida, IValida
    {
        public Asdep.Common.DAO.T_ErroriIODao Esegui(string valore)
        {
            if (!valore.ToUpper().Equals("NO"))
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("004");
            }
            return Errore;
        }
    }
    public class ValidaSoggettoEsistente : Valida, IValida 
    {
        public T_ErroriIODao Esegui(string valore)
        {
            try 
            {
                SoggettoDao _sogg = new SoggettoDao();
                SoggettoService _service = new SoggettoService();
                _sogg = _service.GetByCF(valore);
                if (_sogg != null && _sogg.CodiceFiscale == null) 
                {
                    ErroriIOService _serviceE = new ErroriIOService();
                    Errore = _serviceE.GetById("023");
                }
            }
            catch { }
            return Errore;
        }
    }
    public class ValidaCapoNucleo : Valida, IValida 
    {
        public T_ErroriIODao Esegui(string cfcn, string cfca)
        {
            //caso in cui soggetto.codicefiscaleassicurato = soggetto.codicefiscalecaponucleo
            //allora ho già trovato il caponucleo

            if (cfcn.Equals(cfca))
                return Errore;


            //caso in cui codicefiscaleassicurato e codicefiscale caponucleo siano diversi
            //devo cercare un soggetto per cui cfcn e cfca coincidano

            else 
            {
                AssicuratiService _service = new AssicuratiService();
                SoggettiImportAppoggioDao cn = _service.GetSoggettoCapoNucleo(cfcn);
                if (cn == null) 
                {
                    ErroriIOService _serviceE = new ErroriIOService();
                    Errore = _serviceE.GetById("001");
                }
            }

            return Errore;
        }

        public T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }

    public class EsisteSoggCN : Valida, IValida
    {
        public T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Cerca soggetto capo nucleo
        /// </summary>
        /// <param name="cfcn">Codice fiscale capo nucleo</param>
        /// <param name="cfca">Codice fiscale assicurato</param>
        /// <returns></returns>
        public T_ErroriIODao Esegui(string cfca, string cfcn)
        {
            //caso in cui soggetto.codicefiscaleassicurato = soggetto.codicefiscalecaponucleo
            //allora ho già trovato il caponucleo

            if (cfcn.Equals(cfca))
                return Errore;


            //caso in cui codicefiscaleassicurato e codicefiscale caponucleo siano diversi
            //devo cercare un soggetto per cui cfcn e cfca coincidano

            else
            {
                SoggettoService _service = new SoggettoService();
                SoggettoDao cn = _service.SelectCNByCF(cfcn);
                if (cn == null)
                {
                    ErroriIOService _serviceE = new ErroriIOService();
                    Errore = _serviceE.GetById("023");
                }
            }

            return Errore;
        }
    }

    public class ValidaEta : Valida, IValida 
    {
        public T_ErroriIODao Esegui(int eta, string codTipoAdesione, string codSogg, string codLegame)
        {
            T_LimitiEtaService service = new T_LimitiEtaService();
            if(!service.EtaValida(eta,codTipoAdesione,codSogg,codLegame))
            {
                ErroriIOService _service = new ErroriIOService();
                Errore = _service.GetById("027");
            }
            return Errore;
        }

        public T_ErroriIODao Esegui(string valore)
        {
            throw new NotImplementedException();
        }
    }

}
