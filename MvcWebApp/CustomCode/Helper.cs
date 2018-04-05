using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.ServiceModel.Web;
using WcfService.DAL;
using WcfService;

namespace MvcWebApp.CustomCode
{
    public class Helper
    {
        HSSFWorkbook hssfworkbook;
        private System.Data.DataSet dataSet1 = new DataSet();

        public void InitializeWorkbook(string path)
        {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //book1.xls is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
        }

        public void ConvertToDataTable()
        {
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            DataTable dt = new DataTable();
            //for (int j = 0; j < 5; j++)
            //{
            //dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
            dt.Columns.Add("Convenzione");
            dt.Columns.Add("Categoria");
            dt.Columns.Add("Esclusioni");
            dt.Columns.Add("NumeroPolizza");
            dt.Columns.Add("Ente");
            dt.Columns.Add("Cognome");
            dt.Columns.Add("Nome");
            dt.Columns.Add("SecondoNome");
            dt.Columns.Add("CodiceFiscaleAssicurato");
            dt.Columns.Add("LuogoNascitaAssicurato");
            dt.Columns.Add("DataNascitaAssicurato");
            dt.Columns.Add("CodiceFiscaleCapoNucleo");
            dt.Columns.Add("LegameNucleo");
            dt.Columns.Add("Effetto");
            dt.Columns.Add("IndirizzoResidenza");
            dt.Columns.Add("LocalitaResidenza");
            dt.Columns.Add("SiglaProvResidenza");
            dt.Columns.Add("CapResidenza");
            dt.Columns.Add("Iban");
            dt.Columns.Add("Email");
            dt.Columns.Add("Telefono");
            dt.Columns.Add("DataCessazione");
            dt.Columns.Add("");

            // }

            while (rows.MoveNext())
            {
                IRow row = (HSSFRow)rows.Current;
                DataRow dr = dt.NewRow();

                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);

                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }

            dt.Rows.RemoveAt(0);
            dataSet1.Tables.Add(dt);
            InsertIntoTableAppoggio(dataSet1);
        }

        public int InsertIntoTableAppoggio(DataSet dataset)
        {
            int result = -1;

            try
            {
                List<Anagrafica> anagrafiche = new List<Anagrafica>();
                DataTableCollection tables = dataset.Tables;
                anagrafiche = Extensions.ToList<Anagrafica>(dataset.Tables[0]);

                Uri baseAddress = new Uri("http://localhost:49672/AsdepWcf.svc");
                WebServiceHost host = new WebServiceHost(typeof(AsdepWcf), baseAddress);
                host.Open();

                WebChannelFactory<IAsdepWcf> cf = new WebChannelFactory<IAsdepWcf>(baseAddress);
                IAsdepWcf channel = cf.CreateChannel();
                //int s;

                //s = channel.InsertSoggettiAppoggio(anagrafiche);

            }

            catch { }

            return result;
        }
    }

    public class HelperService : IDisposable
    {
        Uri baseAddress = new Uri("http://localhost:49672/AsdepWcf.svc");
        WebServiceHost host;
        public IAsdepWcf channel { get; set; }

        public HelperService()
        {
            host = new WebServiceHost(typeof(AsdepWcf), baseAddress);
            host.Open();

            WebChannelFactory<IAsdepWcf> cf = new WebChannelFactory<IAsdepWcf>(baseAddress);
            channel = cf.CreateChannel();
        }

        public void Dispose()
        {
            host.Close();
        }
    }
}