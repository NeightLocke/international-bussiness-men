using InternationalBusinessBaseTracing.Interfaces;
using InternationalBusinessDataManager.Interfaces;
using InternationalBusinessDTOs;
using InternationalBusinessFileManager.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace InternationalBusinessDataManager
{
    public class DataManager : IDataManager
    {
        private IPersistentManager _fileProvider;
        private readonly IDataProvider _jsonProvider;
        private readonly ITracing _myTracing;

        public IEnumerable<Rates> RatesList { get; set; }
        public IEnumerable<Transaction> TransactionsList { get; set; }

        public DataManager(IPersistentManager fileProvider, IDataProvider jsonProvider, ITracing myTracing)
        {
            this._fileProvider = fileProvider;
            this._jsonProvider = jsonProvider;
            this._myTracing = myTracing;
        }

        public IEnumerable<Rates> GetRates()
        {
            _myTracing.Debug(string.Format("{0} --- {1}", nameof(DataManager), nameof(GetRates)));
            string endpoint = ConfigurationManager.AppSettings["RatesUrl"];
            if (string.IsNullOrEmpty(endpoint))
            {
                _myTracing.Error(string.Format("Rates Url could not be found in config"));
                throw new NullReferenceException();
            }

            string json = _jsonProvider.GetDataFromUri(endpoint);

            try
            {
                RatesList = new List<Rates>();
                RatesList = JsonConvert.DeserializeObject<List<Rates>>(json);
            }
            catch (Exception ex)
            {
                _myTracing.Error(string.Format("Error when DeserializeObject was invoke : {0}", ex.Message));
                throw ex;
            }
            Task.Run(() => _fileProvider.Write(RatesList));
            return RatesList;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            _myTracing.Debug(string.Format("{0} --- {1}", nameof(DataManager), nameof(GetTransactions)));
            string endpoint = ConfigurationManager.AppSettings["TransactionsUrl"];
            if (string.IsNullOrEmpty(endpoint))
            {
                _myTracing.Error(string.Format("TransactionsUrl Url could not be found in config"));
                throw new NullReferenceException();
            }

            string json = _jsonProvider.GetDataFromUri(endpoint);

            try
            {
                TransactionsList = new List<Transaction>();
                TransactionsList = JsonConvert.DeserializeObject<List<Transaction>>(json);
            }
            catch (Exception ex)
            {
                _myTracing.Error(string.Format("Error when DeserializeObject was invoke : {0}", ex.Message));
                throw ex;
            }
            Task.Run(() => _fileProvider.Write(TransactionsList));
            return TransactionsList;
        }

        public IEnumerable<Transaction> GetTransactionsBySku(string sku)
        {
            _myTracing.Debug(string.Format("{0} --- {1}", nameof(DataManager), nameof(GetTransactionsBySku)));
            double sum = 0;
            try
            {
                if (RatesList == null)
                {
                    _myTracing.Error(string.Format("RatesList is empty"));
                    throw new NullReferenceException();
                }
                if (TransactionsList == null)
                {
                    _myTracing.Error(string.Format("TransactionsList is empty"));
                    throw new NullReferenceException();
                }
                List<Transaction> resultFiltered = new List<Transaction>();
                resultFiltered = TransactionsList.Where(x => x.Sku.Equals(sku)).ToList();
                if (!resultFiltered.Any())
                {
                    _myTracing.Error(string.Format("SKU not found"));
                    return resultFiltered;
                }
                foreach (Transaction element in resultFiltered)
                {
                    if (element.Currency.Equals("EUR"))
                    {
                        sum += element.Amount;
                        continue;
                    }

                    Rates rate = RatesList.Where((r => (r.From == element.Currency) && (r.To.Equals("EUR")))).FirstOrDefault();
                    if (rate != null)
                    {
                        element.Amount *= rate.Rate;
                        element.Currency = "EUR";
                        sum += element.Amount;
                        continue;
                    }
                }
                return resultFiltered;
            }
            catch (Exception ex)
            {
                _myTracing.Error(string.Format("Error while the data has been filtering : {0}", ex.Message));
                throw ex;
            }
        }
    }
}