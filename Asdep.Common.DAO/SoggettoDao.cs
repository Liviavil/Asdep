﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asdep.Common.DAO
{
    public class SoggettoDao
    {
        public long IdSoggetto { get; set; }
        public string CodiceFiscale { get; set; }
        public string Nome { get; set; }
        public string SecondoNome { get; set; }
        public string Cognome { get; set; }
        public System.DateTime DataNascita { get; set; }
        public string IndirizzoResidenza { get; set; }
        public string ComuneResidenza { get; set; }
        public string SiglaProvinciaResidenza { get; set; }
        public string CapResidenza { get; set; }
        public string Email { get; set; }
        public string IBAN { get; set; }
        public string Telefono { get; set; }
        public Nullable<System.DateTime> DataModificaOpzione { get; set; }
        public Nullable<long> IdDanteCausa { get; set; }
        public string StatoRecord { get; set; }
        public string Fonte { get; set; }
        public string FonteModifica { get; set; }
        public System.DateTime DataInizio { get; set; }
        public System.DateTime DataFine { get; set; }
        public Nullable<System.DateTime> DataAggiornamento { get; set; }
        public string CodiceUtente { get; set; }
        public string CodAppl { get; set; }
    }
}
