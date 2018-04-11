using AsdepGestioneAnagraficheBLL.Business;
using AsdepGestioneAnagraficheBLL.Model;
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

        internal static Errore Check(string columnName, SoggettiImportatiAppoggioBL _sogg)
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
                        return new Errore();

                }
            }
            catch { return new Errore(); }
        }

        private static Errore ValidaEmail(string email)
        {
            Errore erro = new Errore();
            bool validemail = new EmailAddressAttribute().IsValid(email);
            if (!validemail)
            {
                erro.ColumnName = "Email";
                erro.Description = "Formato non valido.";
                erro.ErrorLevel = Errore.Level.High;
                erro.Exist = true;
            }
            return erro;
        }

        private static Errore ValidaDataCess(DateTime? nullable)
        {
            throw new NotImplementedException();
        }

        private static Errore ValidaTelefono(string p)
        {
            throw new NotImplementedException();
        }

        private static Errore ValidaIban(string iban)
        {
            Errore erro = new Errore();
            if (string.IsNullOrEmpty(iban))
            {
                erro.ColumnName = "Iban";
                erro.Description = "Valore mancante";
                erro.ErrorLevel = Errore.Level.Warning;
                erro.Exist = true;
            }
            if (!ValidateBankAccount(iban))
            {
                erro.ColumnName = "Iban";
                erro.Description = "Valore non corretto";
                erro.ErrorLevel = Errore.Level.High;
                erro.Exist = true;
            }
            return erro;
        }

        private static Errore ValidaCapResid(string p)
        {
            throw new NotImplementedException();
        }

        private static Errore ValidaSiglaProv(string p)
        {
            throw new NotImplementedException();
        }

        private static Errore ValidaLocResid(string p)
        {
            throw new NotImplementedException();
        }

        private static Errore ValidaIndirizzoResid(string p)
        {
            throw new NotImplementedException();
        }

        private static Errore ValidaEffetto(DateTime? nullable)
        {
            throw new NotImplementedException();
        }

        private static Errore ValidaLegame(string legame)
        {
            Errore erro = new Errore();
            T_TipoLegameService _eService = new T_TipoLegameService();
            T_TipoLegameBL legameBL = _eService.GetByCodLegame(legame);
            if (legameBL.CodLegameImport == null)
            {
                erro.ColumnName = "Codice Legame";
                erro.Description = "Valore non censito dal sistema";
                erro.ErrorLevel = Errore.Level.High;
                erro.Exist = true;
            }
            return erro;
        }

        private static Errore ValidaDataNascita(DateTime? nullable)
        {
            throw new NotImplementedException();
        }

        private static Errore ValidaLuogoNascita(string p)
        {
            throw new NotImplementedException();
        }

        private static Errore ValidaCFCapoNucleo(string p)
        {
            throw new NotImplementedException();
        }

        private static Errore ValidaCategoria(string categoria)
        {
            Errore erro = new Errore();
            if (!categoria.ToLower().Equals("dipendenti"))
            {
                erro.ColumnName = "Categoria";
                erro.Description = "Valore non valido";
                erro.ErrorLevel = Errore.Level.High;
                erro.Exist = true;
            }
            return erro;
        }

        private static Errore ValidaConvenzione(string p)
        {
            throw new NotImplementedException();
        }

        private static Errore ValidaPolizza(string polizza)
        {
            Errore erro = new Errore();
            if (!polizza.ToLower().Equals("base_integrativa") || !polizza.ToLower().Equals("base") || !polizza.ToLower().Equals("integrativa"))
            {
                erro.ColumnName = "Polizza";
                erro.Description = "Valore non valido";
                erro.ErrorLevel = Errore.Level.High;
                erro.Exist = true;
            }
            return erro;
        }

        private static Errore ValidaCFAssic(string p)
        {
            throw new NotImplementedException();
        }

        private static Errore ValidaEnte(string ente)
        {
            Errore erro = new Errore();
            EnteService _eService = new EnteService();
            EnteBL enteBL = _eService.SelectByCodiceEnte(ente);
            if (ente == null || ente.ToString().Equals(string.Empty))
            {
                erro.ColumnName = "Ente";
                erro.Description = "Ente non presente";
                erro.ErrorLevel = Errore.Level.High;
                erro.Exist = true;
            }
            return erro;
        }

        private static Errore ValidaEsclusioni(string esclusione)
        {
            Errore erro = new Errore();
            if (!esclusione.ToUpper().Equals("NO"))
            {
                erro.ColumnName = "Esclusioni Pregresse";
                erro.Description = "Valore di default errato";
                erro.ErrorLevel = Errore.Level.High;
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


        public static class PropertyCopier<TParent, TChild>
            where TParent : class
            where TChild : class
        {
            public static void Copy(TParent parent, TChild child)
            {
                var parentProperties = parent.GetType().GetProperties();
                var childProperties = child.GetType().GetProperties();
                foreach (var parentProperty in parentProperties)
                {
                    foreach (var childProperty in childProperties)
                    {
                        if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                        {
                            childProperty.SetValue(child, parentProperty.GetValue(parent)); break;
                        }
                    }
                }
            }
        }
    }
}
