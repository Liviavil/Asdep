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
        private ErroreDao _errore;

        public ErroreDao Errore
        {
            get { return _errore; }
            set { _errore = value; }
        }

        public Valida()
        {
            Errore = new ErroreDao();
        }
    }

    public class ValidaEmail : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            bool validemail = new EmailAddressAttribute().IsValid(soggetto.Email);
            if (!validemail)
            {
                Errore.ColumnName = "Email";
                Errore.Description = "Formato non valido.";
                Errore.ErrorLevel = ErroreDao.Level.High;
                Errore.Exist = true;
            }
            return Errore;
        }
    }

    public class ValidaDataCessazione : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            throw new NotImplementedException();
        }
    }

    public class ValidaTelefono : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            throw new NotImplementedException();
        }
    }

    public class ValidaIban : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            if (string.IsNullOrEmpty(soggetto.Iban)) 
            {
                Errore.ColumnName = "Iban";
                Errore.Description = "Valore mancante";
                Errore.ErrorLevel = ErroreDao.Level.Warning;
                Errore.Exist = true;
            }          
            if (!Helper.ValidateBankAccount(soggetto.Iban)) 
            {
                Errore.ColumnName = "Iban";
                Errore.Description = "Valore non corretto";
                Errore.ErrorLevel = ErroreDao.Level.High;
                Errore.Exist = true;
            }
                
            return Errore;
        }
    }

    public class ValidaCapResid : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            throw new NotImplementedException();
        }
    }

    public class ValidaSiglaProv : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaLocResid : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaIndirizzoResid : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaEffetto : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaLegame : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            T_TipoLegameService _eService = new T_TipoLegameService();
            T_TipiLegameDao legameBL = _eService.GetByCodLegame(soggetto.LegameNucleo);
            if (legameBL.CodLegameImport == null)
            {
                Errore.ColumnName = "Codice Legame";
                Errore.Description = "Valore non censito dal sistema";
                Errore.ErrorLevel = ErroreDao.Level.High;
                Errore.Exist = true;
            }
            return Errore;
        }
    }
    public class ValidaDataNascita : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaLuogoNascita : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaCFCapoNucleo : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaCategoria : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            if (!soggetto.Categoria.ToLower().Equals("dipendenti"))
            {
                Errore.ColumnName = "Categoria";
                Errore.Description = "Valore non valido";
                Errore.ErrorLevel = ErroreDao.Level.High;
                Errore.Exist = true;
            }
            return Errore;
        }
    }
    public class ValidaConvenzione : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaPolizza : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            if (!soggetto.NumeroPolizza.ToLower().Equals("base_integrativa") || !soggetto.NumeroPolizza.ToLower().Equals("base"))
            {
                Errore.ColumnName = "Polizza";
                Errore.Description = "Valore non valido";
                Errore.ErrorLevel = ErroreDao.Level.High;
                Errore.Exist = true;
            }
            return Errore;
        }
    }
    public class ValidaCFAssic : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            throw new NotImplementedException();
        }
    }
    public class ValidaEnte : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            EnteService _eService = new EnteService();
            EnteDao enteBL = _eService.SelectByCodiceEnte(soggetto.Ente);
            if (soggetto.Ente == null || soggetto.Ente.ToString().Equals(string.Empty))
            {
                Errore.ColumnName = "Ente";
                Errore.Description = "Ente non presente";
                Errore.ErrorLevel = ErroreDao.Level.High;
                Errore.Exist = true;
            }
            return Errore;
        }
    }
    public class ValidaEsclusioni : Valida, IValida
    {
        public Asdep.Common.DAO.ErroreDao Esegui(Asdep.Common.DAO.SoggettiImportAppoggioDao soggetto)
        {
            if (!soggetto.EsclusioniPregresse.ToUpper().Equals("NO"))
            {
                Errore.ColumnName = "Esclusioni Pregresse";
                Errore.Description = "Valore di default errato";
                Errore.ErrorLevel = ErroreDao.Level.High;
                Errore.Exist = true;
            }
            return Errore;
        }
    }

}
