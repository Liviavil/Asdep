using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Asdep.Common.DAO;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAsdepWcf
    {
        // CRUD per la gestione delle anagrafiche
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "CancellaAnagrafica")]
        bool CancellaAnagrafica();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "CaricaAnagrafica/")]
        int CaricaAnagrafica(SoggettiImportAppoggioDao anagrafica);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ValidaAnagrafica")]
        bool ValidaAnagrafica();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAnagrafica")]
        SoggettiImportAppoggioDao GetAnagrafica();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetSoggettiImportAnagrafica")]
        SoggettiImportAppoggioDao GetSoggettiImportAnagrafica();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "InsertSoggettoAppoggio/")]
        int InsertSoggettoAppoggio(SoggettiImportAppoggioDao anagrafica);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "InsertSoggettiAppoggio/")]
        int InsertSoggettiAppoggio(List<SoggettiImportAppoggioDao> anagrafiche, string tipoTracciato);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetEnti/")]
        List<EnteDao> GetAllEnti();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllEntiInLavorazione/")]
        List<string> GetAllEntiInLavorazione();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetSoggettiByEnte/")]
        List<SoggettiImportAppoggioDao> GetSoggettiByEnte(string ente, string tipoTracciato);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "DeleteAnagraficaByEnte/")]
        int DeleteAnagraficaByEnte(string ente, string TipoTracciato);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetTipoLegameByCodiceIn/")]
        T_TipiLegameDao GetByCode(string codice);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ValidaSoggetto/")]
        void ValidaSoggetto(List<SoggettiImportAppoggioDao> soggetto, string tipoTracciato);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UpdateSoggImportato/")]
        void UpdateSoggImportato(SoggettiImportAppoggioDao sogg, List<T_ErroriIODao> errori);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ValidaSoggettoSingolo/")]
        void ValidaSoggettoSingolo(SoggettiImportAppoggioDao soggetto, string tipoTracciato);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "SelectById/")]
        SoggettiImportAppoggioDao SelectById(long id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetContribuzionEnteByNome/")]
        ContribuzioneEnteDao GetContribuzionEnteByNome(string nome);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "DeleteSoggettoImportato/")]
        void DeleteSoggettoImportato(long id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "InviaAdesione/")]
        bool InviaAdesioneSoggettiImportati(string cf, string tipoTracciato);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetCategorieAdesioni/")]
        List<T_CategoriaAdesioneDao> GetCategorieAdesioni();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetTipoSoggetti/")]
        List<T_TipoSoggettoDao> GetTipoSoggetti();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetTipoAdesioni/")]
        List<T_TipoAdesioneDao> GetTipoAdesioni();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetTipiLegame/")]
        List<T_TipiLegameDao> GetTipiLegame();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "RicercaAdesioni/")]
        List<AdesioneDao> RicercaAdesioni();

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAdesioneById/")]
        AdesioneDao GetAdesioneById(long id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ModificaAdesione/")]
        AdesioneDao ModificaAdesione(long id);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "SalvaAdesione/")]
        int SalvaAdesione(AdesioneDao _dao);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "CessazioneAdesione/")]
        int CessazioneAdesione(AdesioneDao _dao);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "AggiungiAdesione/")]
        int AggiungiAdesione(AdesioneDao _dao);

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "VerificaAdesione/")]
        List<T_ErroriIODao> VerificaAdesione(AdesioneDao dao);
    }
}
