using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asdep.Common.DAO;

namespace MvcWebApp.Models
{
    public class AdesioneModel
    {
        public AdesioneDao Adesione { get; set; }
        public SoggettoDao Soggetto { get; set; }
        public int Eta { get; set; }
        public string Categoria { get; set; }
        public string Polizza { get; set; }
        public string Legame { get; set; }
        public string CFCapoNucleo { get; set; }

    }
}