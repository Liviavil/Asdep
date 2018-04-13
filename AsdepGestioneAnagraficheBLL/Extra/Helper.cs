using Asdep.Common.DAO;
using AsdepGestioneAnagraficheBLL.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Extra
{
    public static class Helper
    {

        internal static ErroreDao Check(string columnName, SoggettiImportAppoggioDao _sogg)
        {
            try
            {
                switch (columnName)
                {
                    case "EsclusioniPregresse":
                        return ValidaEsclusioni(_sogg.EsclusioniPregresse);
                    case "Ente":
                        return ValidaEnte(_sogg.Ente);
                    case "CodiceFiscaleAssicurato":
                        return ValidaCFAssic(_sogg.CodiceFiscaleAssicurato);
                    case "NumeroPolizza":
                        return ValidaPolizza(_sogg.NumeroPolizza);
                    case "Convenzione":
                        return ValidaConvenzione(_sogg.Convenzione);
                    case "Categoria":
                        return ValidaCategoria(_sogg.Categoria);
                    case "CodiceFiscaleCapoNucleo":
                        return ValidaCFCapoNucleo(_sogg.CodiceFiscaleCapoNucleo);
                    case "LuogoNascitaAssicurato":
                        return ValidaLuogoNascita(_sogg.LuogoNascitaAssicurato);
                    case "DataNascitaAssicurato":
                        return ValidaDataNascita(_sogg.DataNascitaAssicurato);
                    case "LegameNucleo":
                        return ValidaLegame(_sogg.LegameNucleo);
                    case "Effetto":
                        return ValidaEffetto(_sogg.Effetto);
                    case "IndirizzoResidenza":
                        return ValidaIndirizzoResid(_sogg.IndirizzoResidenza);
                    case "LocalitaResidenza":
                        return ValidaLocResid(_sogg.LocalitaResidenza);
                    case "SiglaProvResidenza":
                        return ValidaSiglaProv(_sogg.SiglaProvResidenza);
                    case "CapResidenza":
                        return ValidaCapResid(_sogg.CapResidenza);
                    case "Iban":
                        return ValidaIban(_sogg.Iban);
                    case "Telefono":
                        return ValidaTelefono(_sogg.Telefono);
                    case "DataCessazione":
                        return ValidaDataCess(_sogg.DataCessazione);
                    case "Email":
                        return ValidaEmail(_sogg.Email);
                    default:
                        return new ErroreDao();

                }
            }
            catch { return new ErroreDao(); }
        }

        private static ErroreDao ValidaEmail(string email)
        {
            ErroreDao erro = new ErroreDao();
            bool validemail = new EmailAddressAttribute().IsValid(email);
            if (!validemail)
            {
                erro.ColumnName = "Email";
                erro.Description = "Formato non valido.";
                erro.ErrorLevel = ErroreDao.Level.High;
                erro.Exist = true;
            }
            return erro;
        }

        private static ErroreDao ValidaDataCess(DateTime? nullable)
        {
            throw new NotImplementedException();
        }

        private static ErroreDao ValidaTelefono(string p)
        {
            throw new NotImplementedException();
        }

        private static ErroreDao ValidaIban(string iban)
        {
            ErroreDao erro = new ErroreDao();
            if (string.IsNullOrEmpty(iban))
            {
                erro.ColumnName = "Iban";
                erro.Description = "Valore mancante";
                erro.ErrorLevel = ErroreDao.Level.Warning;
                erro.Exist = true;
            }
            if (!ValidateBankAccount(iban))
            {
                erro.ColumnName = "Iban";
                erro.Description = "Valore non corretto";
                erro.ErrorLevel = ErroreDao.Level.High;
                erro.Exist = true;
            }
            return erro;
        }

        private static ErroreDao ValidaCapResid(string p)
        {
            throw new NotImplementedException();
        }

        private static ErroreDao ValidaSiglaProv(string p)
        {
            throw new NotImplementedException();
        }

        private static ErroreDao ValidaLocResid(string p)
        {
            throw new NotImplementedException();
        }

        private static ErroreDao ValidaIndirizzoResid(string p)
        {
            throw new NotImplementedException();
        }

        private static ErroreDao ValidaEffetto(DateTime? nullable)
        {
            throw new NotImplementedException();
        }

        private static ErroreDao ValidaLegame(string legame)
        {
            ErroreDao erro = new ErroreDao();
            T_TipoLegameService _eService = new T_TipoLegameService();
            T_TipiLegameDao legameBL = _eService.GetByCodLegame(legame);
            if (legameBL.CodLegameImport == null)
            {
                erro.ColumnName = "Codice Legame";
                erro.Description = "Valore non censito dal sistema";
                erro.ErrorLevel = ErroreDao.Level.High;
                erro.Exist = true;
            }
            return erro;
        }

        private static ErroreDao ValidaDataNascita(DateTime? nullable)
        {
            throw new NotImplementedException();
        }

        private static ErroreDao ValidaLuogoNascita(string p)
        {
            throw new NotImplementedException();
        }

        private static ErroreDao ValidaCFCapoNucleo(string p)
        {
            throw new NotImplementedException();
        }

        private static ErroreDao ValidaCategoria(string categoria)
        {
            ErroreDao erro = new ErroreDao();
            if (!categoria.ToLower().Equals("dipendenti"))
            {
                erro.ColumnName = "Categoria";
                erro.Description = "Valore non valido";
                erro.ErrorLevel = ErroreDao.Level.High;
                erro.Exist = true;
            }
            return erro;
        }

        private static ErroreDao ValidaConvenzione(string p)
        {
            throw new NotImplementedException();
        }

        private static ErroreDao ValidaPolizza(string polizza)
        {
            ErroreDao erro = new ErroreDao();
            if (!polizza.ToLower().Equals("base_integrativa") || !polizza.ToLower().Equals("base") || !polizza.ToLower().Equals("integrativa"))
            {
                erro.ColumnName = "Polizza";
                erro.Description = "Valore non valido";
                erro.ErrorLevel = ErroreDao.Level.High;
                erro.Exist = true;
            }
            return erro;
        }

        private static ErroreDao ValidaCFAssic(string p)
        {
            throw new NotImplementedException();
        }

        private static ErroreDao ValidaEnte(string ente)
        {
            ErroreDao erro = new ErroreDao();
            EnteService _eService = new EnteService();
            EnteDao enteBL = _eService.SelectByCodiceEnte(ente);
            if (ente == null || ente.ToString().Equals(string.Empty))
            {
                erro.ColumnName = "Ente";
                erro.Description = "Ente non presente";
                erro.ErrorLevel = ErroreDao.Level.High;
                erro.Exist = true;
            }
            return erro;
        }

        private static ErroreDao ValidaEsclusioni(string esclusione)
        {
            ErroreDao erro = new ErroreDao();
            if (!esclusione.ToUpper().Equals("NO"))
            {
                erro.ColumnName = "Esclusioni Pregresse";
                erro.Description = "Valore di default errato";
                erro.ErrorLevel = ErroreDao.Level.High;
                erro.Exist = true;
            }
            return erro;
        }


        public static bool ValidateBankAccount(string bankAccount)
        {
            bankAccount = bankAccount.ToUpper(); //IN ORDER TO COPE WITH THE REGEX BELOW
            if (String.IsNullOrEmpty(bankAccount))
                return false;
            else if (System.Text.RegularExpressions.Regex.IsMatch(bankAccount, "^[A-Z0-9]"))
            {
                bankAccount = bankAccount.Replace(" ", String.Empty);
                string bank =
                bankAccount.Substring(4, bankAccount.Length - 4) + bankAccount.Substring(0, 4);
                int asciiShift = 55;
                StringBuilder sb = new StringBuilder();
                foreach (char c in bank)
                {
                    int v;
                    if (Char.IsLetter(c)) v = c - asciiShift;
                    else v = int.Parse(c.ToString());
                    sb.Append(v);
                }
                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }
                return checksum == 1;
            }
            else
                return false;
        }
    }
}
