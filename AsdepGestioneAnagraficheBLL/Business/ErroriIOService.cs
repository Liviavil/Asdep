﻿using AmministrazioneAsdep;
using AmministrazioneAsdep.DAL;
using Asdep.Common.DAO;
using Asdep.Common.DAO.ExtraDao;
using AsdepGestioneAnagraficheBLL.Extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL.Business
{
    public class ErroriIOService : IServiceAsdep<T_ErroriIODao>
    {
        AmministrazioneAsdepEntities db;
        public ErroriIOService()
        {
            db = new AmministrazioneAsdepEntities();
        }

        public T_ErroriIODao GetById(string codice) 
        {
            T_ErroriIO _errore = new T_ErroriIO();
            T_ErroriIODao _eDao = new T_ErroriIODao();
            ErroriIOProvider provider = new ErroriIOProvider();
            _errore = provider.SelectById(db, codice);
            Asdep.Common.DAO.ExtraDao.PropertyCopier<T_ErroriIO, T_ErroriIODao>.Copy(_errore, _eDao);
            return _eDao;
        }
        public int AddOne(T_ErroriIODao obj)
        {
            throw new NotImplementedException();
        }

        public int AddMany(List<T_ErroriIODao> obj)
        {
            throw new NotImplementedException();
        }

        public List<T_ErroriIODao> GetAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(T_ErroriIODao obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(List<T_ErroriIODao> objs)
        {
            throw new NotImplementedException();
        }

        public List<T_ErroriIODao> ValidaAdesioneCollettiva(SoggettiImportAppoggioDao sogg)
        {
            List<T_ErroriIODao> errori = new List<T_ErroriIODao>();

            //IValida _validazione = new ValidaIban();
            //errori.Add(_validazione.Esegui(sogg.Iban));
            IValida _validazione = new ValidaEnte();
            errori.Add(_validazione.Esegui(sogg.Ente));
            ValidaCapoNucleo _validazionecn = new ValidaCapoNucleo();
            errori.Add(_validazionecn.Esegui(sogg.CodiceFiscaleCapoNucleo,sogg.CodiceFiscaleAssicurato));
            _validazione = new ValidaCFAssic();
            errori.Add(_validazione.Esegui(sogg.CodiceFiscaleAssicurato));
            _validazione = new ValidaCFCapoNucleo();
            errori.Add(_validazione.Esegui(sogg.CodiceFiscaleCapoNucleo));
            _validazione = new ValidaPolizza();
            errori.Add(_validazione.Esegui(sogg.NumeroPolizza));
            _validazione = new ValidaCategoria();
            errori.Add(_validazione.Esegui(sogg.Categoria));
            _validazione = new ValidaLegame();
            errori.Add(_validazione.Esegui(sogg.LegameNucleo));
            _validazione = new ValidaEsclusioni();
            errori.Add(_validazione.Esegui(sogg.EsclusioniPregresse));
            ValidaNome _validazioneNome = new ValidaNome();
            errori.Add(_validazioneNome.Esegui(sogg.CodiceFiscaleAssicurato,sogg.Nome));
            ValidaCognome _validazioneCogn = new ValidaCognome();
            errori.Add(_validazioneCogn.Esegui(sogg.CodiceFiscaleAssicurato, sogg.Cognome));
            ValidaEffetto _validazioneEff = new ValidaEffetto();
            errori.Add(_validazioneEff.Esegui(sogg.Effetto, sogg.Ente));
            ValidaDataNascita _validazioneData = new ValidaDataNascita();
            errori.Add(_validazioneData.Esegui(sogg.CodiceFiscaleAssicurato, sogg.DataNascitaAssicurato));

            return errori.Where(e => e.DescErrore != null).ToList();
            #region old
            //List<ErroreDao> errori = new List<ErroreDao>();
            //const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;

            //var objFieldNames = typeof(SoggettiImportAppoggioDao).GetProperties(flags).Cast<PropertyInfo>().
            //   Select(item => new
            //   {
            //       Name = item.Name,
            //       Type = Nullable.GetUnderlyingType(item.PropertyType) ?? item.PropertyType
            //   }).ToList();

            //errori = new List<ErroreDao>();
            //foreach (var obj in objFieldNames)
            //{
            //    ErroreDao errore = new ErroreDao();
            //    errore = Helper.Check(obj.Name, sogg);
            //    errori.Add(errore);
            //}

            //return errori; 
            #endregion
        }
    }
}
