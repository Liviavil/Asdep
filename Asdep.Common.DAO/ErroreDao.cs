using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO
{
    public class ErroreDao
    {
        public string ColumnName { get; set; }
        public string Description { get; set; }
        public Level ErrorLevel { get; set; }
        public bool Exist { get; set; }

        public enum Level
        {
            Warning,
            High
        }
    }
}
