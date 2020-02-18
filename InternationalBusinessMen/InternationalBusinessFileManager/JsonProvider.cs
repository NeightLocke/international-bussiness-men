using InternationalBusinessBaseTracing.Interfaces;
using InternationalBusinessFileManager.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessFileManager
{
    public class JsonProvider : IDataProvider
    {
        private readonly ITracing _myTracing;

        public JsonProvider(ITracing myTracing)
        {
            this._myTracing = myTracing;
        }

        public string GetDataFromUri(string endpoint)
        {
            try
            {
                #region WebRequest

                WebRequest request = WebRequest.Create(endpoint);
                request.Method = "GET";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                #endregion

                #region Deserialize

                Stream sr = response.GetResponseStream();
                StreamReader reader = new StreamReader(sr);
                string json = reader.ReadToEnd();
                reader.Close();
                sr.Close();
                response.Close();
                return json;

                #endregion
            }
            catch (Exception ex)
            {
                _myTracing.Error(string.Format(ex.Message));
                throw ex;
            }
        }
    }
}
