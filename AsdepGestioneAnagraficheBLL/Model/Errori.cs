using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsdepGestioneAnagraficheBLL.Model
{
    public class Errore
    {
        private bool _errore;

        public string ColumnName { get; set; }
        public string Description { get; set; }
        public Level ErrorLevel { get; set; }
        public bool Exist { get { return _errore; } set { _errore = value; } }
        

        public enum Level
        {
            Warning,
            High
        }
    }
}
