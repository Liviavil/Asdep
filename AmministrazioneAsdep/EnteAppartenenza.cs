//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmministrazioneAsdep
{
    using System;
    using System.Collections.Generic;
    
    public partial class EnteAppartenenza
    {
        public long IdEnte { get; set; }
        public long IdSoggetto { get; set; }
        public System.DateTime DataInizio { get; set; }
        public System.DateTime DataFine { get; set; }
        public System.DateTime DataAggiornamento { get; set; }
        public string CodiceUtente { get; set; }
        public string CodAppl { get; set; }
    
        public virtual Ente Ente { get; set; }
        public virtual Soggetto Soggetto { get; set; }
    }
}
