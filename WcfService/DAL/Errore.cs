using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfService.DAL
{
    public class Errore
    {
        public string ColumnName { get; set; }
        public string Description { get; set; }
        public Level ErrorLevel { get; set; }
        public bool Exists { get; set; }

        public enum Level 
        {
            Warning,
            High
        }

    }
}
