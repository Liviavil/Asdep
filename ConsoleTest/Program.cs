using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asdep.Common.DAO;
using System.Reflection;
using AsdepGestioneAnagraficheBLL;
using System.Text.RegularExpressions;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Asdep.Common.DAO.SoggettiImportAppoggioDao obj = new Asdep.Common.DAO.SoggettiImportAppoggioDao();
            //List<string>  stringhe = new List<string> ();
            //Type objtype = obj.GetType();
            
            //foreach (PropertyInfo p in objtype.GetProperties())
            //{
            //    foreach (Attribute a in p.GetCustomAttributes(false))
            //    {
            //        Asdep.Common.DAO.ExtraDao.Attributecustom c = (Asdep.Common.DAO.ExtraDao.Attributecustom)a;
            //        stringhe.Add(c.DisplayName);
            //    }
            //}
            bool cf = AsdepGestioneAnagraficheBLL.Extra.CodiceFiscale.ControlloFormaleOK("crslvi87h59b114n");//("livia", "crescenzo", new DateTime(1987, 6, 19), 'F', "b114");
            string data = AsdepGestioneAnagraficheBLL.Extra.CodiceFiscale.GetDateFromFiscalCode("crslvi87h59b114n");
            //Regex regex = new Regex("/^(?:(?:[B-DF-HJ-NP-TV-Z]|[AEIOU])[AEIOU][AEIOUX]|[B-DF-HJ-NP-TV-Z]{2}[A-Z]){2}[\dLMNP-V]{2}(?:[A-EHLMPR-T](?:[04LQ][1-9MNP-V]|[1256LMRS][\dLMNP-V])|[DHPS][37PT][0L]|[ACELMRT][37PT][01LM])(?:[A-MZ][1-9MNP-V][\dLMNP-V]{2}|[A-M][0L](?:[1-9MNP-V][\dLMNP-V]|[0L][1-9MNP-V]))[A-Z]$/i");
            //regex.Match("crslvi87h59");
            var test = AsdepGestioneAnagraficheBLL.Extra.Helper.IsFiscalCodeOk("crslvi87h59b114n".ToUpper());
        }
    }
}
