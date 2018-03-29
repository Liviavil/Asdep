using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfService.DAL
{
    [DataContract]
    public class Anagrafica
    {
        private string _convenzione;

        [DataMember]
        public string Convenzione
        {
            get { return _convenzione; }
            set { _convenzione = value; }
        }
        string _categoria;

        [DataMember]
        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
        bool _esclusioniPregresse;

        [DataMember]
        public bool EsclusioniPregresse
        {
            get { return _esclusioniPregresse; }
            set { _esclusioniPregresse = value; }
        }
        string _numeroPolizzaEnte;

        [DataMember]
        public string NumeroPolizzaEnte
        {
            get { return _numeroPolizzaEnte; }
            set { _numeroPolizzaEnte = value; }
        }
        string _cognome;

        [DataMember]
        public string Cognome
        {
            get { return _cognome; }
            set { _cognome = value; }
        }
        string _nome;


        [DataMember]
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        string _codiceFiscaleAssicurato;


        [DataMember]
        public string CodiceFiscaleAssicurato
        {
            get { return _codiceFiscaleAssicurato; }
            set { _codiceFiscaleAssicurato = value; }
        }
        string _luogoNascita;


        [DataMember]
        public string LuogoNascita
        {
            get { return _luogoNascita; }
            set { _luogoNascita = value; }
        }
        DateTime _dataNascita;


        [DataMember]
        public DateTime DataNascita
        {
            get { return _dataNascita; }
            set { _dataNascita = value; }
        }
        string _codiceFiscaleCapoNucleo;


        [DataMember]
        public string CodiceFiscaleCapoNucleo
        {
            get { return _codiceFiscaleCapoNucleo; }
            set { _codiceFiscaleCapoNucleo = value; }
        }
        string _legameNucleo;


        [DataMember]
        public string LegameNucleo
        {
            get { return _legameNucleo; }
            set { _legameNucleo = value; }
        }
        string _residenza;


        [DataMember]
        public string Residenza
        {
            get { return _residenza; }
            set { _residenza = value; }
        }
        string _siglaProvResidenza;


        [DataMember]
        public string SiglaProvResidenza
        {
            get { return _siglaProvResidenza; }
            set { _siglaProvResidenza = value; }
        }
        string _capResidenza;


        [DataMember]
        public string CapResidenza
        {
            get { return _capResidenza; }
            set { _capResidenza = value; }
        }
        string _iban;


        [DataMember]
        public string Iban
        {
            get { return _iban; }
            set { _iban = value; }
        }
        string _email;


        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        string _telefono;


        [DataMember]
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        DateTime _dataCessazione;


        [DataMember]
        public DateTime DataCessazione
        {
            get { return _dataCessazione; }
            set { _dataCessazione = value; }
        }
    }
}