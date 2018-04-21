using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Design;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class SoggettiImportAppoggioProvider : IProvider<SoggettiImportAppoggio>
    {
        public List<SoggettiImportAppoggio> GetByEnte(AmministrazioneAsdepEntities db, string nomeEnte)
        {
            List<SoggettiImportAppoggio> assicurati = new List<SoggettiImportAppoggio>();

            try
            {
                assicurati = (from table in db.SoggettiImportAppoggio where table.Ente.Equals(nomeEnte) select table).ToList();
            }
            catch (Exception ex)
            {
            }

            return assicurati;
        }

        public List<SoggettiImportAppoggio> GetAll(AmministrazioneAsdepEntities db)
        {
            List<SoggettiImportAppoggio> _assicurati = new List<SoggettiImportAppoggio>();
            try
            {
                _assicurati = (from table in db.SoggettiImportAppoggio select table).ToList();
            }
            catch { }
            return _assicurati;
        }

        public SoggettiImportAppoggio SelectById(AmministrazioneAsdepEntities db, long id)
        {
            SoggettiImportAppoggio _sogg = new SoggettiImportAppoggio();
            try
            {
                _sogg = (from table in db.SoggettiImportAppoggio where table.IdSoggetto.Equals(id) select table).FirstOrDefault();
            }
            catch { }
            return _sogg;
        }

        public List<SoggettiImportAppoggio> Find(AmministrazioneAsdepEntities db, SoggettiImportAppoggio obj)
        {
            throw new NotImplementedException();
        }

        public int AddOne(AmministrazioneAsdepEntities db, SoggettiImportAppoggio obb)
        {
            int result = -1;
            try
            {
                db.SoggettiImportAppoggio.Add(obb);
                result = db.SaveChanges();

                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int AddMany(AmministrazioneAsdepEntities db, List<SoggettiImportAppoggio> objs)
        {
            int result = -1;
            try
            {
                foreach (SoggettiImportAppoggio _ass in objs)
                {
                    db.SoggettiImportAppoggio.Add(_ass);
                    result = db.SaveChanges();
                }

                return result;
            }
            catch (Exception ex) { return -1; }
        }

        public int Update(AmministrazioneAsdepEntities db, SoggettiImportAppoggio obj, string errori)
        {
            int result = -1;
            using (db = new AmministrazioneAsdepEntities())
            {
                SoggettiImportAppoggio soggetto = db.SoggettiImportAppoggio.FirstOrDefault(x => x.IdSoggetto.Equals(obj.IdSoggetto));
                Asdep.Common.DAO.ExtraDao.PropertyCopier<SoggettiImportAppoggio, SoggettiImportAppoggio>.Copy(obj, soggetto);
                soggetto.Errori = errori;

                db.SaveChanges();
            }
            return result;
        }

        public int DeleteOne(AmministrazioneAsdepEntities db, SoggettiImportAppoggio obj)
        {
            int result = -1;
            try
            {
                db.Entry(obj).State = EntityState.Deleted;
                //db.SoggettiImportAppoggio.Remove(obj);
                result = db.SaveChanges();
            }
            catch { }
            return result;
        }

        public int DeleteMany(AmministrazioneAsdepEntities db, List<SoggettiImportAppoggio> objs)
        {
            int result = -1;
            try
            {
                db.SoggettiImportAppoggio.RemoveRange(objs);
                //foreach (SoggettiImportAppoggio _ass in objs)
                //{
                //    SoggettiImportAppoggio _s = SelectById(db, _ass.IdSoggetto);
                //    db.SoggettiImportAppoggio.Remove(_s);
                //    result = db.SaveChanges();
                //}
                result = db.SaveChanges();
            }
            catch { }
            return result;
        }

        public int DeleteByEnte(AmministrazioneAsdepEntities db, string ente)
        {
            int result = -1;
            try
            {
                db.SoggettiImportAppoggio.RemoveRange(db.SoggettiImportAppoggio.Where(x => x.Ente.Equals(ente)));
                db.SaveChanges();

            }
            catch { }
            return result;
        }

        public SoggettiImportAppoggio GetSoggettoCapoNucleo(AmministrazioneAsdepEntities db, string codicefiscale)
        {
            SoggettiImportAppoggio _s = new SoggettiImportAppoggio();
            try
            {
                _s = db.SoggettiImportAppoggio.Where(s => s.CodiceFiscaleAssicurato.Equals(s.CodiceFiscaleCapoNucleo).Equals(codicefiscale)).FirstOrDefault();
            }
            catch { }
            return _s;
        }


        public int Update(AmministrazioneAsdepEntities db, SoggettiImportAppoggio obj)
        {
            throw new NotImplementedException();
        }

        public List<SoggettiImportAppoggio> GetNucleoByCN(AmministrazioneAsdepEntities db, string codiceFiscaleCN)
        {
            List<SoggettiImportAppoggio> soggetti = new List<SoggettiImportAppoggio>();
            try
            {
                soggetti = (from table in db.SoggettiImportAppoggio
                            where table.CodiceFiscaleCapoNucleo.Equals(codiceFiscaleCN)
                                && !table.CodiceFiscaleAssicurato.Equals(table.CodiceFiscaleCapoNucleo)
                            select table).ToList();
            }
            catch { }
            return soggetti;
        }

        public void FormalizzaAdesione(AmministrazioneAsdepEntities db, SoggettiImportAppoggio _capoNucleo, List<SoggettiImportAppoggio> famiglia)
        {
            List<string> codiciAdesioneCollettive = new List<string> { "001", "002", "003", "004", "005" };
            try
            {
                using (db = new AmministrazioneAsdepEntities())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Soggetto _soggCN = new Soggetto();

                            #region Esiste il soggetto capo nucleo importato nella tabella Soggetto

                            //Trovare il capo nucleo nella tabella Soggetto (CF, Nome, Cognome)
                            _soggCN = (from SoggTable in db.Soggetto
                                       where SoggTable.CodiceFiscale.Equals(_capoNucleo.CodiceFiscaleAssicurato)
                                           && SoggTable.Nome.Equals(_capoNucleo.Nome) && SoggTable.Cognome.Equals(_capoNucleo.Cognome)
                                           && SoggTable.IdDanteCausa == null
                                       select SoggTable).FirstOrDefault();

                            /*******  Soggetto esistente, aggiorno i dati   *******/
                            if (_soggCN != null)
                            {
                                #region Soggetto esistente
                                _soggCN.IdDanteCausa = _soggCN.IdSoggetto;
                                if (_capoNucleo.DataNascitaAssicurato != null)
                                {
                                    _soggCN.DataNascita = DateTime.Parse(_capoNucleo.DataNascitaAssicurato.ToString());
                                }
                                _soggCN.IndirizzoResidenza = _capoNucleo.IndirizzoResidenza;
                                _soggCN.SiglaProvinciaResidenza = _capoNucleo.SiglaProvResidenza;
                                _soggCN.CapResidenza = _capoNucleo.CapResidenza;
                                _soggCN.Email = _capoNucleo.Email;
                                _soggCN.IBAN = _capoNucleo.Iban;
                                _soggCN.Telefono = _capoNucleo.Telefono;
                                #endregion
                            }
                            else
                            {
                                /****        Nuovo record nella tabella soggetti           ***/

                                #region Nuovo soggetto
                                _soggCN.CodiceFiscale = _capoNucleo.CodiceFiscaleAssicurato;
                                _soggCN.Nome = _capoNucleo.Nome;
                                _soggCN.CodiceFiscale = _capoNucleo.Cognome;
                                if (_capoNucleo.DataNascitaAssicurato != null)
                                {
                                    _soggCN.DataNascita = DateTime.Parse(_capoNucleo.DataNascitaAssicurato.ToString());
                                }
                                _soggCN.IndirizzoResidenza = _capoNucleo.IndirizzoResidenza;
                                _soggCN.SiglaProvinciaResidenza = _capoNucleo.SiglaProvResidenza;
                                _soggCN.CapResidenza = _capoNucleo.CapResidenza;
                                _soggCN.Email = _capoNucleo.Email;
                                _soggCN.IBAN = _capoNucleo.Iban;
                                _soggCN.Telefono = _capoNucleo.Telefono;
                                #endregion

                                db.Soggetto.Add(_soggCN);
                            }
                            #endregion

                            EnteAppartenenza _soggCapo = new EnteAppartenenza();
                            EnteAppartenenza _enteApp = new EnteAppartenenza();

                            #region Tabella EnteAppartenenza
                            //Verificare presenza del record Soggetto Capo nucleo nella tabella ente appartenenza
                            _soggCapo = (from EnteApp in db.EnteAppartenenza
                                         where
                                             EnteApp.IdSoggetto.Equals(_soggCN.IdSoggetto)
                                             && EnteApp.DataInizio < _capoNucleo.Effetto
                                             && _capoNucleo.Effetto < EnteApp.DataFine
                                         select EnteApp).SingleOrDefault();

                            if (_soggCapo != null)
                            {
                                /***  Se il record è presente controllare il valore dell'Ente che sia congruente con il valore del soggetto importato     *  
                                 *    altrimenti significa che lo stesso soggetto ha cambiato ente di appartenenza e vanno aggiornate alcune info         ***/

                                string ente = (from EnteApp in db.EnteAppartenenza join EnteT in db.Ente on EnteApp.IdEnte equals EnteT.IdEnte select EnteT.CodiceEnte).ToString();

                                if (!ente.Equals(_capoNucleo.Ente))
                                {
                                    /***** Chiudere occorrenza esistente aggiornare data effetto,inserire nuovo record in EnteApp per il nuovo ente , aggiornare adesioni collettive    *****/
                                    _soggCapo.DataFine = _capoNucleo.Effetto.Subtract(new TimeSpan(1, 0, 0, 0));

                                    /***Aggiungo nuova occorrenza Ente Appartenenza per il nuovo ente**/

                                    _enteApp.IdEnte = long.Parse((from EnteTab in db.Ente where EnteTab.CodiceEnte.Equals(_capoNucleo.Ente) select EnteTab.IdEnte).ToString());
                                    _enteApp.IdSoggetto = _soggCN.IdSoggetto;
                                    _enteApp.DataInizio = _capoNucleo.Effetto;
                                    _enteApp.DataFine = _capoNucleo.Effetto.AddDays(1).AddYears(1);
                                    db.EnteAppartenenza.Add(_enteApp);



                                    List<Adesione> adesioniSoggetti = (from AdesioniTable in db.Adesione
                                                                       where
                                                                           AdesioniTable.IdCaponucleo.Equals(_soggCN.IdSoggetto)
                                                                           && codiciAdesioneCollettive.Contains(AdesioniTable.CodTipoAdesione)
                                                                           && AdesioniTable.DataInizio < _capoNucleo.Effetto
                                                                           && _capoNucleo.Effetto < AdesioniTable.DataFine
                                                                       select AdesioniTable
                                                                       ).ToList();

                                    foreach (Adesione Ad in adesioniSoggetti)
                                    {
                                        Ad.DataCessazione = _capoNucleo.Effetto.Subtract(new TimeSpan(1, 0, 0, 0));
                                        Ad.DataFine = _capoNucleo.Effetto.Subtract(new TimeSpan(1, 0, 0, 0));
                                    }

                                }

                            }
                            #endregion

                            Adesione _nuovaAdesione = new Adesione();

                            #region Adesione caponucelo
                            //*** adesione del capo nucleo    ***///
                            Adesione adesioniSoggetto = (from AdesioniTable in db.Adesione
                                                         where
                                                             AdesioniTable.IdSoggetto.Equals(_soggCN.IdSoggetto)
                                                             && codiciAdesioneCollettive.Contains(AdesioniTable.CodTipoAdesione)
                                                             && AdesioniTable.DataInizio < _capoNucleo.Effetto
                                                             && _capoNucleo.Effetto < AdesioniTable.DataFine
                                                         select AdesioniTable
                                                               ).FirstOrDefault();


                            if (adesioniSoggetto != null)
                            {
                                adesioniSoggetto.DataCessazione = new DateTime(2019, 7, 1);//_capoNucleo.Effetto.Subtract(new TimeSpan(1, 0, 0, 0));
                                adesioniSoggetto.DataFine = new DateTime(2019, 7, 1);//_capoNucleo.Effetto.Subtract(new TimeSpan(1, 0, 0, 0));
                            }
                            else
                            {
                                _nuovaAdesione.IdCaponucleo = _soggCN.IdSoggetto;
                                _nuovaAdesione.IdSoggetto = _soggCN.IdSoggetto;
                                _nuovaAdesione.CodTipoAdesione = (from TipoAdesione in db.T_TipoAdesione
                                                                  where TipoAdesione.DescBreve.ToUpper().Equals(_capoNucleo.NumeroPolizza.ToUpper())
                                                                  select TipoAdesione.CodTipoAdesione).ToString();
                                _nuovaAdesione.DataCessazione = new DateTime(2019, 7, 1);//_capoNucleo.Effetto.Subtract(new TimeSpan(1, 0, 0, 0));
                                _nuovaAdesione.DataFine = new DateTime(2019, 7, 1);//_capoNucleo.Effetto.Subtract(new TimeSpan(1, 0, 0, 0));
                                _nuovaAdesione.DataInizio = _capoNucleo.Effetto;
                                db.Adesione.Add(_nuovaAdesione);
                            }
                            #endregion
                            //******STORICO ADESIONI capo nucleo*****//

                            /*******************    Ciclo per i famigliari           **********************/

                            #region Famigliari
                            foreach (SoggettiImportAppoggio _fami in famiglia)
                            {
                                Soggetto _famigliare = new Soggetto();
                                #region Tabella Soggetto
                                _famigliare = (from SoggTable in db.Soggetto
                                               where SoggTable.CodiceFiscale.Equals(_fami.CodiceFiscaleAssicurato)
                                               && SoggTable.Nome.Equals(_capoNucleo.Nome) && SoggTable.Cognome.Equals(_fami.Cognome)
                                               && SoggTable.IdDanteCausa == _soggCN.IdSoggetto
                                               select SoggTable).FirstOrDefault();

                                if (_famigliare != null)
                                {
                                    //Aggiornare
                                }
                                else
                                {
                                    //Creare

                                    db.Soggetto.Add(_famigliare);
                                }
                                #endregion

                                #region Tabella Adesione

                                Adesione adesioniSoggettoFami = (from AdesioniTable in db.Adesione
                                                                 where
                                                                     AdesioniTable.IdSoggetto.Equals(_famigliare.IdSoggetto)
                                                                     && codiciAdesioneCollettive.Contains(AdesioniTable.CodTipoAdesione)
                                                                     && AdesioniTable.DataInizio < _capoNucleo.Effetto
                                                                     && _capoNucleo.Effetto < AdesioniTable.DataFine
                                                                 select AdesioniTable
                                                                ).FirstOrDefault();


                                if (adesioniSoggetto != null)
                                {
                                    adesioniSoggetto.DataCessazione = new DateTime(2019, 7, 1);//_capoNucleo.Effetto.Subtract(new TimeSpan(1, 0, 0, 0));
                                    adesioniSoggetto.DataFine = new DateTime(2019, 7, 1);//_capoNucleo.Effetto.Subtract(new TimeSpan(1, 0, 0, 0));
                                }
                                else
                                {
                                    _nuovaAdesione.IdCaponucleo = _soggCN.IdSoggetto;
                                    _nuovaAdesione.IdSoggetto = _famigliare.IdSoggetto;
                                    _nuovaAdesione.CodTipoAdesione = (from TipoAdesione in db.T_TipoAdesione
                                                                      where TipoAdesione.DescBreve.ToUpper().Equals(_fami.NumeroPolizza.ToUpper())
                                                                      select TipoAdesione.CodTipoAdesione).ToString();
                                    _nuovaAdesione.DataCessazione = new DateTime(2019, 7, 1);//_capoNucleo.Effetto.Subtract(new TimeSpan(1, 0, 0, 0));
                                    _nuovaAdesione.DataFine = new DateTime(2019, 7, 1);//_capoNucleo.Effetto.Subtract(new TimeSpan(1, 0, 0, 0));
                                    _nuovaAdesione.DataInizio = _fami.Effetto;
                                    db.Adesione.Add(_nuovaAdesione);
                                }
                                #endregion
                            } 
                            #endregion


                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch 
                        {
                            transaction.Rollback();
                        }
                    }
                }

            }
            catch(Exception e) 
            {
            }
        }
    }
}
