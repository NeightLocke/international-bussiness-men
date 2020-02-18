using InternationalBusinessDataManager.Interfaces;
using InternationalBusinessDTOs;
using InternationalBusinessServiceLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessServiceLibrary
{
    public class InternationalBusinessService : IInternationalBusinessService
    {
        private readonly IDataManager _dataManager;
        private readonly InternationalBusinessBaseTracing.Interfaces.ITracing _myTracing;

        public InternationalBusinessService(IDataManager dataManager, InternationalBusinessBaseTracing.Interfaces.ITracing myTracing)
        {
            this._dataManager = dataManager;
            this._myTracing = myTracing;
        }

        public IEnumerable<Rates> GetRates()
        {
            _myTracing.Debug(string.Format("{0} --- {1} --- {2}", nameof(InternationalBusinessService), nameof(GetRates), "WCF"));
            return _dataManager.GetRates();
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            _myTracing.Debug(string.Format("{0} --- {1} --- {2}", nameof(InternationalBusinessService), nameof(GetTransactions), "WCF"));
            return _dataManager.GetTransactions();
        }

        public IEnumerable<Transaction> GetTransactionsBySku(string sku)
        {
            _myTracing.Debug(string.Format("{0} --- {1} --- {2}", nameof(InternationalBusinessService), nameof(GetTransactionsBySku), "WCF"));
            return _dataManager.GetTransactionsBySku(sku);
        }
    }
}