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
    
    public partial class T_StatoAdesione
    {
        public T_StatoAdesione()
        {
            this.Adesione = new HashSet<Adesione>();
        }
    
        public string CodStatoAdesione { get; set; }
        public string DescStatoAdesione { get; set; }
        public System.DateTime DataInizio { get; set; }
        public System.DateTime DataFine { get; set; }
        public System.DateTime DataAggiornamento { get; set; }
        public string CodiceUtente { get; set; }
        public string CodAppl { get; set; }
    
        public virtual ICollection<Adesione> Adesione { get; set; }
    }
}
