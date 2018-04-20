using System;
using System.Collections.Generic;
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
            using (db = new AmministrazioneAsdepEntities ())
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
                db.SoggettiImportAppoggio.Remove(obj);
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
                db.SoggettiImportAppoggio.RemoveRange(db.SoggettiImportAppoggio.Where(x=>x.Ente.Equals(ente)));
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
    }
}
