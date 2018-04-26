using Asdep.Common.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebApp.Models
{
    public class SearchAdesioniModel
    {
        public string selectedEnte { get; set; }
        public SelectList ListItemEnti { get; set; }

        public string selectedTipoSoggetto { get; set; }
        public SelectList ListItemTipoSoggetto { get; set; }

        public string selectedTipoAdesione { get; set; }
        public SelectList ListItemTipoAdesione { get; set; }

        public string selectedLegami { get; set; }
        public SelectList ListItemLegami { get; set; }

        public string Nome { get; set; }
        public string Cognome { get; set; }

        public List<Asdep.Common.DAO.AdesioneDao> Results { get; set; }
    }
}