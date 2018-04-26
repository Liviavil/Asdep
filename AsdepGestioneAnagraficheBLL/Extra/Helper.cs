using Asdep.Common.DAO;
using AsdepGestioneAnagraficheBLL.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Extra
{
    public static class Helper
    {

        public static bool IsFiscalCodeOk(string fiscalCode)
        {
            const string regex = @"/^(?:(?:[B-DF-HJ-NP-TV-Z]|[AEIOU])[AEIOU][AEIOUX]|[B-DF-HJ-NP-TV-Z]{2}[A-Z]){2}[\dLMNP-V]{2}(?:[A-EHLMPR-T](?:[04LQ][1-9MNP-V]|[1256LMRS][\dLMNP-V])|[DHPS][37PT][0L]|[ACELMRT][37PT][01LM])(?:[A-MZ][1-9MNP-V][\dLMNP-V]{2}|[A-M][0L](?:[1-9MNP-V][\dLMNP-V]|[0L][1-9MNP-V]))[A-Z]$/i";//@"[\dLMNP-V]{2}(?:[A-EHLMPR-T](?:[04LQ][1-9MNP-V]|[1256LMRS][\dLMNP-V])|[DHPS][37PT][0L]|[ACELMRT][37PT][01LM])(?:[A-MZ][1-9MNP-V][\dLMNP-V]{2}|[A-M][0L](?:[1-9MNP-V][\dLMNP-V]|[0L][1-9MNP-V]))";//@"/^(?:[B-DF-HJ-NP-TV-Z](?:[AEIOU]{2}|[AEIOU]X)|[AEIOU]{2}X|[B-DF-HJ-NP-TV-Z]{2}[A-Z]){2}[\dLMNP-V]{2}(?:[A-EHLMPR-T](?:[04LQ][1-9MNP-V]|[1256LMRS][\dLMNP-V])|[DHPS][37PT][0L]|[ACELMRT][37PT][01LM])(?:[A-MZ][1-9MNP-V][\dLMNP-V]{2}|[A-M][0L](?:[\dLMNP-V][1-9MNP-V]|[1-9MNP-V][0L]))[A-Z]$/i";
            if (!Regex.IsMatch(fiscalCode, regex))
                return false;

            #region static maps

            var oddMap = new Dictionary<char, int>() {
				{'0', 1},
				{'1', 0},
				{'2', 5},
				{'3', 7},
				{'4', 9},
				{'5', 13},
				{'6', 15},
				{'7', 17},
				{'8', 19},
				{'9', 21},
				{'A', 1},
				{'B', 0},
				{'C', 5},
				{'D', 7},
				{'E', 9},
				{'F', 13},
				{'G', 15},
				{'H', 17},
				{'I', 19},
				{'J', 21},
				{'K', 2},
				{'L', 4},
				{'M', 18},
				{'N', 20},
				{'O', 11},
				{'P', 3},
				{'Q', 6},
				{'R', 8},
				{'S', 12},
				{'T', 14},
				{'U', 16},
				{'V', 10},
				{'W', 22},
				{'X', 25},
				{'Y', 24},
				{'Z', 23}
			};

            var evenMap = new Dictionary<char, int>() {
				{'0', 0},
				{'1', 1},
				{'2', 2},
				{'3', 3},
				{'4', 4},
				{'5', 5},
				{'6', 6},
				{'7', 7},
				{'8', 8},
				{'9', 9},
				{'A', 0},
				{'B', 1},
				{'C', 2},
				{'D', 3},
				{'E', 4},
				{'F', 5},
				{'G', 6},
				{'H', 7},
				{'I', 8},
				{'J', 9},
				{'K', 10},
				{'L', 11},
				{'M', 12},
				{'N', 13},
				{'O', 14},
				{'P', 15},
				{'Q', 16},
				{'R', 17},
				{'S', 18},
				{'T', 19},
				{'U', 20},
				{'V', 21},
				{'W', 22},
				{'X', 23},
				{'Y', 24},
				{'Z', 25}
			};

            #endregion static maps

            int total = 0;
            for (int i = 0; i < 15; i += 2)
                total += oddMap[fiscalCode[i]];
            for (int i = 1; i < 15; i += 2)
                total += evenMap[fiscalCode[i]];

            return fiscalCode[15] == (char)('A' + total % 26);
        }

        public static bool ValidateBankAccount(string bankAccount)
        {
            bankAccount = bankAccount.ToUpper(); //IN ORDER TO COPE WITH THE REGEX BELOW
            if (String.IsNullOrEmpty(bankAccount))
                return false;
            if (bankAccount.Length != 27)
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

        internal static bool CheckDataEffettoDataContrEnte(DateTime? valore, string ente)
        {
            bool result = false;
            try 
            {
                ContribuzioneEnteService _service = new ContribuzioneEnteService();
                ContribuzioneEnteDao _ce = _service.SelectByNomeEnte(ente);
                if(_ce!=null  && !_ce.DataFine.ToString().Equals(string.Empty))
                {
                    DateTime _ceData = DateTime.Parse(_ce.DataFine.ToString());
                    DateTime _data = DateTime.Parse(valore.ToString());
                    if (_data.CompareTo(_ceData) < 0 ) 
                    {
                        result = true;
                    }
                }
            }
            catch { }
            return result;
        }

        public static int CalculateAge(DateTime birthDay)
        {
            int years = DateTime.Now.Year - birthDay.Year;

            if ((birthDay.Month > DateTime.Now.Month) || (birthDay.Month == DateTime.Now.Month && birthDay.Day > DateTime.Now.Day))
                years--;

            return years;
        }
    }
}
