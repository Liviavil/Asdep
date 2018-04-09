using System;
using System.Collections.Generic;
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

        public int Update(AmministrazioneAsdepEntities db, SoggettiImportAppoggio obj)
        {
            throw new NotImplementedException();
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
                foreach (SoggettiImportAppoggio _ass in objs)
                {
                    SoggettiImportAppoggio _s = SelectById(db,_ass.IdSoggetto);
                    db.SoggettiImportAppoggio.Remove(_s);
                    result = db.SaveChanges();
                }
            }
            catch { }
            return result;
        }
    }
}
