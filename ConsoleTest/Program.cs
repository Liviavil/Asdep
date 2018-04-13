using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asdep.Common.DAO;
using System.Reflection;


namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Asdep.Common.DAO.SoggettiImportAppoggioDao obj = new Asdep.Common.DAO.SoggettiImportAppoggioDao();
            List<string>  stringhe = new List<string> ();
            Type objtype = obj.GetType();
            
            foreach (PropertyInfo p in objtype.GetProperties())
            {
                foreach (Attribute a in p.GetCustomAttributes(false))
                {
                    Asdep.Common.DAO.ExtraDao.Attributecustom c = (Asdep.Common.DAO.ExtraDao.Attributecustom)a;
                    stringhe.Add(c.DisplayName);
                }
            }
            


            
        }
    }
}
