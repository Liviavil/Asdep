using Asdep.GestioneAnagraficeDAL;
using AsdepGestioneAnagraficheBLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdepGestioneAnagraficheBLL
{
    public class AssicuratiService : IServiceAsdep<AssicuratiBL>
    {
        private ASSICURATI_ASDEPEntities db;

        public AssicuratiService()
        {
            db = new ASSICURATI_ASDEPEntities();
        }

        public List<AssicuratiBL> GetAll()
        {
            List<AssicuratiBL> lst = new List<AssicuratiBL>();
            try
            {
                using (db)
                {
                    List<ASSICURATI> _assicuratiDal = Asdep.GestioneAnagraficeDAL.Provider.AssicuratiProvider.GetAllAssicurati(db);
                    if (_assicuratiDal.Any())
                    {
                        foreach (ASSICURATI _as in _assicuratiDal)
                        {
                            AssicuratiBL _asBL = new AssicuratiBL(_as);
                            lst.Add(_asBL);
                        }
                    }
                }

            }
            catch (Exception ex) { }
            return lst;
        }

        public int AddMany(List<AssicuratiBL> _assicurati)
        {
            int result = -1;
            try
            {
                List<ASSICURATI> assToAdd = new List<ASSICURATI>();
                if (_assicurati.Any())
                {
                    foreach (AssicuratiBL _assBL in _assicurati)
                    {
                        assToAdd.Add(_assBL);
                    }
                }
                using (db)
                {

                    result = Asdep.GestioneAnagraficeDAL.Provider.AssicuratiProvider.AddAssicurati(db, assToAdd);
                }
            }
            catch (Exception ex) { result = -1; }
            return result;
        }

        public int AddOne(AssicuratiBL assicurato)
        {
            int result = -1;
            try
            {
                ASSICURATI _assicurato = new ASSICURATI
                {
                    Id_Assicurato = assicurato.Id_Assicurato,
                    Cognome = assicurato.Cognome,
                    Nome = assicurato.Nome,
                    Codice_fiscale_assicurato = assicurato.Codice_fiscale_assicurato,
                    Codice_fiscale_caponucleo = assicurato.Codice_fiscale_caponucleo,
                    Ente = assicurato.Ente,
                    CodiceLegame = assicurato.CodiceLegame,
                    Data_Effetto = assicurato.Data_Effetto,
                    Data_inserimento = assicurato.Data_inserimento,
                    Data_ultimo_aggiornamento = assicurato.Data_ultimo_aggiornamento,
                    Convenzione = assicurato.Convenzione,
                    Categoria = assicurato.Categoria,
                    Numero_Polizza = assicurato.Numero_Polizza,
                    Data_cessazione = assicurato.Data_cessazione,
                    Luogo_nascita_assicurato = assicurato.Luogo_nascita_assicurato,
                    Progressivo = assicurato.Progressivo,
                    Matricola = assicurato.Matricola
                };

                using (db)
                {
                    result = Asdep.GestioneAnagraficeDAL.Provider.AssicuratiProvider.AddAssicurato(db, _assicurato);
                }
            }
            catch (Exception ex)
            {
                result = -1;
            }
            return result;
        }
    }
}
