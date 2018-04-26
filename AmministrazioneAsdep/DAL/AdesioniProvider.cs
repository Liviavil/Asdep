using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmministrazioneAsdep.DAL
{
    public class AdesioniProvider : IProvider<Adesione>
    {
        public List<Adesione> GetAll(AmministrazioneAsdepEntities db)
        {
            throw new NotImplementedException();
        }

        public Adesione SelectById(AmministrazioneAsdepEntities db, long id)
        {
            Adesione _ad = null;
            _ad = (from AdesioneTbl in db.Adesione where AdesioneTbl.IdAdesione.Equals(id) select AdesioneTbl).FirstOrDefault();
            return _ad;

        }

        public List<Adesione> Find(AmministrazioneAsdepEntities db, Adesione obj)
        {
            throw new NotImplementedException();
        }

        public int AddOne(AmministrazioneAsdepEntities db, Adesione obb)
        {
            int result = -1;
            try
            {
                using (db = new AmministrazioneAsdepEntities())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Adesione newAdesione = new Adesione();
                            Soggetto newSogg = new Soggetto();

                            Adesione adesioneOld = (from AdesioneTable in db.Adesione
                                                    join SoggettoTable in db.Soggetto on AdesioneTable.IdSoggetto equals SoggettoTable.IdSoggetto
                                                    join StatoAdesioneTable in db.T_StatoAdesione on AdesioneTable.StatoAdesione equals StatoAdesioneTable.CodStatoAdesione
                                                    where SoggettoTable.Nome.Equals(obb.Soggetto.Nome) &&
                                                    SoggettoTable.Cognome.Equals(obb.Soggetto.Cognome) &&
                                                    SoggettoTable.CodiceFiscale.Equals(obb.Soggetto.CodiceFiscale) &&
                                                    AdesioneTable.DataInizio < DateTime.Now &&
                                                    DateTime.Now < AdesioneTable.DataFine &&
                                                    StatoAdesioneTable.CodStatoAdesione.Equals("02")
                                                    select AdesioneTable).FirstOrDefault();

                            if (adesioneOld != null)
                                throw new Exception("Esiste già una adesione valida, impossibile completare l'operazione di creazione");
                            else
                            {

                                Soggetto soggettoOld = (from SoggTable in db.Soggetto
                                                        where SoggTable.Nome.Equals(obb.Soggetto.Nome) &&
                                                        SoggTable.Cognome.Equals(obb.Soggetto.Cognome) &&
                                                        SoggTable.CodiceFiscale.Equals(obb.Soggetto.CodiceFiscale)
                                                        select SoggTable).FirstOrDefault();
                                #region Soggetto
                                if (soggettoOld == null)
                                {
                                    newSogg.Nome = obb.Soggetto.Nome;
                                    newSogg.Cognome = obb.Soggetto.Cognome;
                                    newSogg.CodiceFiscale = obb.Soggetto.CodiceFiscale;
                                    newSogg.CapResidenza = obb.Soggetto.CapResidenza;
                                    newSogg.ComuneResidenza = obb.Soggetto.ComuneResidenza;
                                    newSogg.DataAggiornamento = DateTime.Now;
                                    newSogg.DataNascita = obb.Soggetto.DataNascita;
                                    newSogg.Email = obb.Soggetto.Email;
                                    newSogg.IBAN = obb.Soggetto.IBAN;
                                    newSogg.IndirizzoResidenza = obb.Soggetto.IndirizzoResidenza;
                                    newSogg.LuogoNascita = obb.Soggetto.LuogoNascita;
                                    newSogg.SecondoNome = obb.Soggetto.SecondoNome;
                                    newSogg.SiglaProvinciaResidenza = obb.Soggetto.SiglaProvinciaResidenza;
                                    newSogg.StatoRecord = "02";
                                    newSogg.Telefono = obb.Soggetto.Telefono;
                                    db.Soggetto.Add(newSogg);
                                }
                                else
                                {
                                    Asdep.Common.DAO.ExtraDao.PropertyCopier<Soggetto, Soggetto>.Copy(obb.Soggetto, soggettoOld);
                                }
                                #endregion

                                if (obb.Soggetto.CodiceFiscale.Equals(obb.Soggetto1.CodiceFiscale))
                                {
                                    if (!obb.CodLegame.Equals("001"))
                                    {
                                        throw new Exception("Inserire un legame corretto per la figura del capo nucleo");

                                    }
                                    else 
                                    {
                                        newAdesione.CodLegame = obb.CodLegame;
                                        newAdesione.CodTipoAdesione = obb.CodTipoAdesione;
                                        newAdesione.CodTipoSoggetto = obb.CodTipoSoggetto;
                                        newAdesione.DataAggiornamento = DateTime.Now;
                                        newAdesione.DataInizio = obb.DataInizio;
                                        newAdesione.IdEnte = obb.IdEnte;
                                        newAdesione.StatoAdesione = "02";

                                        db.Adesione.Add(newAdesione);
                                    }
                                }
                                else
                                {
                                    //adesione per un famigliare
                                    //deve esistere l'adesione valida del caponucleo

                                    Adesione _adesioneCN = (from AdesioneTable in db.Adesione
                                                            join SoggettTable in db.Soggetto on AdesioneTable.IdCaponucleo equals SoggettTable.IdSoggetto
                                                            join StatoAdesioneTable in db.T_StatoAdesione on AdesioneTable.StatoAdesione equals StatoAdesioneTable.CodStatoAdesione
                                                            where SoggettTable.CodiceFiscale.Equals(obb.Soggetto1.CodiceFiscale) &&
                                                            AdesioneTable.DataInizio < DateTime.Now &&
                                                            DateTime.Now < AdesioneTable.DataFine &&
                                                            StatoAdesioneTable.CodStatoAdesione.Equals("02")
                                                            select AdesioneTable).FirstOrDefault();
                                    if (_adesioneCN == null)
                                        throw new Exception("Non esiste una adesione valida per il soggetto: " + obb.Soggetto1.CodiceFiscale);
                                    else 
                                    {
                                        newAdesione.CodLegame = obb.CodLegame;
                                        newAdesione.CodTipoAdesione = obb.CodTipoAdesione;
                                        newAdesione.CodTipoSoggetto = obb.CodTipoSoggetto;
                                        newAdesione.DataAggiornamento = DateTime.Now;
                                        newAdesione.DataInizio = obb.DataInizio;
                                        newAdesione.IdEnte = obb.IdEnte;
                                        newAdesione.StatoAdesione = "02";

                                        db.Adesione.Add(newAdesione);
                                    }
                                }
                            }

                            result = db.SaveChanges();
                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                        }
                    }
                }

            }
            catch (Exception e)
            {
            }
            return result;
        }

        public int AddMany(AmministrazioneAsdepEntities db, List<Adesione> objs)
        {
            throw new NotImplementedException();
        }

        public int Update(AmministrazioneAsdepEntities db, Adesione obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteOne(AmministrazioneAsdepEntities db, Adesione obj)
        {
            throw new NotImplementedException();
        }

        public int DeleteMany(AmministrazioneAsdepEntities db, List<Adesione> objs)
        {
            throw new NotImplementedException();
        }

        public List<Adesione> RicercaAdesione(AmministrazioneAsdepEntities db)
        {
            List<Adesione> result = null;
            result = (from AdesTbl in db.Adesione
                      join SoggTbl in db.Soggetto on AdesTbl.IdSoggetto equals SoggTbl.IdSoggetto
                      join Sogg1Table in db.Soggetto on AdesTbl.IdCaponucleo equals Sogg1Table.IdSoggetto
                      join EnteTable in db.Ente on AdesTbl.IdEnte equals EnteTable.IdEnte
                      join TipoAdesTable in db.T_TipoAdesione on AdesTbl.CodTipoAdesione equals TipoAdesTable.CodTipoAdesione
                      join TipoLegameTable in db.T_TipiLegame on AdesTbl.CodLegame equals TipoLegameTable.CodLegame
                      join TipoSoggTable in db.T_TipoSoggetto on AdesTbl.CodTipoSoggetto equals TipoSoggTable.CodTipoSoggetto
                      select AdesTbl).ToList();

            return result;
        }

        public int SalvaAdesioneCollettiva(AmministrazioneAsdepEntities db, Adesione _ad)
        {
            int result = -1;
            try
            {
                using (db = new AmministrazioneAsdepEntities())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {

                            Adesione adesioneOld = (from AdesioneTable in db.Adesione
                                                    join StatoAdesioneTable in db.T_StatoAdesione on AdesioneTable.StatoAdesione equals StatoAdesioneTable.CodStatoAdesione
                                                    where AdesioneTable.IdAdesione.Equals(_ad.IdAdesione) &&
                                                    AdesioneTable.DataInizio < DateTime.Now &&
                                                    DateTime.Now < AdesioneTable.DataFine &&
                                                    StatoAdesioneTable.CodStatoAdesione.Equals("02")
                                                    select AdesioneTable).FirstOrDefault();

                            if (adesioneOld == null)
                                throw new Exception("Non esiste alcuna adesione valida con i dati inseriti");
                            else
                            {
                                Soggetto soggettoOld = (from SoggTable in db.Soggetto where SoggTable.IdSoggetto.Equals(adesioneOld.IdSoggetto) select SoggTable).FirstOrDefault();

                                if (_ad.Soggetto.CodiceFiscale.Equals(_ad.Soggetto1.CodiceFiscale))
                                {
                                    //è un adesione del capo nucleo
                                    if (!adesioneOld.Ente.CodiceEnte.Equals(_ad.Ente.CodiceEnte))
                                    {
                                        //Sono nel caso in cui il soggetto ha cambiato ente di appartenenza
                                        //Chiudere adesioni riferite al vecchio ente comprese quelle del nucleo ed aprirne una nuova per lui
                                        //Chiudere record EnteDiAppartenenza riferito al vecchio ente

                                        //Adesioni famigliari
                                        List<Adesione> _adesioniNucleo = (from AdesioneTable in db.Adesione
                                                                          where AdesioneTable.IdCaponucleo.Equals(_ad.IdSoggetto)
                                                                              && AdesioneTable.Ente.CodiceEnte.Equals(adesioneOld.Ente.CodiceEnte)
                                                                          select AdesioneTable).ToList();
                                        foreach (Adesione ad in _adesioniNucleo)
                                        {
                                            ad.DataFine = _ad.DataInizio.Subtract(new TimeSpan(1, 0, 0, 0));
                                            ad.DataCessazione = _ad.DataInizio.Subtract(new TimeSpan(1, 0, 0, 0));
                                            ad.StatoAdesione = (from StatoAdesioniTable in db.T_StatoAdesione where StatoAdesioniTable.CodStatoAdesione.Equals("03") select StatoAdesioniTable).Select(x => x.CodStatoAdesione).ToString();
                                        }

                                        //EnteAppartenenza
                                        EnteAppartenenza _soggCapo = new EnteAppartenenza();
                                        _soggCapo = (from EnteAppTable in db.EnteAppartenenza
                                                     where
                                                         EnteAppTable.IdSoggetto.Equals(_ad.IdSoggetto)
                                                         && EnteAppTable.IdEnte.Equals(adesioneOld.IdEnte)
                                                     select EnteAppTable).FirstOrDefault();
                                        if (_soggCapo != null)
                                        {
                                            _soggCapo.DataFine = _ad.DataInizio.Subtract(new TimeSpan(1, 0, 0, 0));

                                            //Aggiungere nuovo Ente appartenenza
                                            EnteAppartenenza _enteApp = new EnteAppartenenza();
                                            _enteApp.IdEnte = long.Parse((from EnteTab in db.Ente where EnteTab.CodiceEnte.Equals(_ad.Ente) select EnteTab.IdEnte).ToString());
                                            _enteApp.IdSoggetto = _ad.IdSoggetto;
                                            _enteApp.DataInizio = _ad.DataInizio;
                                            _enteApp.DataFine = _ad.DataInizio.AddDays(1).AddYears(1);
                                            db.EnteAppartenenza.Add(_enteApp);
                                        }
                                    }
                                    else
                                    {
                                        Asdep.Common.DAO.ExtraDao.PropertyCopier<Adesione, Adesione>.Copy(_ad, adesioneOld);
                                        Asdep.Common.DAO.ExtraDao.PropertyCopier<Soggetto, Soggetto>.Copy(_ad.Soggetto, soggettoOld);
                                    }
                                }
                            }
                            //update adesione e soggetto old
                            result = db.SaveChanges();
                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                        }
                    }
                }

            }
            catch (Exception e)
            {
            }
            return result;
        }

        public int CessazioneAdesioneCollettiva(AmministrazioneAsdepEntities db, Adesione _ad)
        {
            int result = -1;
            try
            {
                using (db = new AmministrazioneAsdepEntities())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            Adesione adesioneOld = (from AdesioneTable in db.Adesione where AdesioneTable.IdAdesione.Equals(_ad.IdAdesione) select AdesioneTable).FirstOrDefault();
                            adesioneOld.DataCessazione = _ad.DataCessazione;
                            adesioneOld.DataFine = _ad.DataCessazione;
                            adesioneOld.StatoAdesione = "03";

                            EnteAppartenenza EnteApp = (from EnteAppTable in db.EnteAppartenenza
                                                        where EnteAppTable.IdSoggetto.Equals(_ad.IdSoggetto) &&
                                                            EnteAppTable.IdEnte.Equals(_ad.IdEnte)
                                                        select EnteAppTable).FirstOrDefault();
                            EnteApp.DataFine = _ad.DataCessazione.Subtract(new TimeSpan(1, 0, 0, 0));

                            result = db.SaveChanges();
                            transaction.Commit();
                        }
                        catch
                        {
                            transaction.Rollback();
                        }
                    }
                }

            }
            catch (Exception e)
            {
            }
            return result;
        }

        public List<Adesione> SelectByIdCapoNucleo(AmministrazioneAsdepEntities db, long id)
        {
            return (from AdesioneTable in db.Adesione where AdesioneTable.IdCaponucleo.Equals(id) select AdesioneTable).ToList();
        }
    }
}
