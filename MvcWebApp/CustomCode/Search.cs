using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWebApp.CustomCode
{
    public class Search<T> where T : class
    {
        public string Selected { get; set; }
        public List<T> Results { get; set; }
        public int CountResults { get; set; }
    }
}