using InternationalBusinessDTOs;
using InternationalBusinessWebApiLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessWebApiLibrary.Adapters
{
    public class InternationalBusinessAdapter : IInternationalBusinessAdapter
    {
        private readonly InternationalBusinessServiceLibrary.Interfaces.IInternationalBusinessService _clientService;
        private readonly InternationalBusinessBaseTracing.Interfaces.ITracing _myTracing;

        public InternationalBusinessAdapter(
            InternationalBusinessServiceLibrary.Interfaces.IInternationalBusinessService clientService,
            InternationalBusinessBaseTracing.Interfaces.ITracing myTracing)
        {
            this._clientService = clientService;
            this._myTracing = myTracing;
        }

        public IEnumerable<Rates> GetRates()
        {
            _myTracing.Debug(string.Format("{0} --- {1} --- {2}", nameof(InternationalBusinessAdapter), nameof(GetRates), "WebApi"));
            return _clientService.GetRates();
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            _myTracing.Debug(string.Format("{0} --- {1} --- {2}", nameof(InternationalBusinessAdapter), nameof(GetTransactions), "WebApi"));
            return _clientService.GetTransactions();
        }

        public IEnumerable<Transaction> GetTransactionsBySku(string sku)
        {
            _myTracing.Debug(string.Format("{0} --- {1} --- {2}", nameof(InternationalBusinessAdapter), nameof(GetTransactionsBySku), "WebApi"));
            return _clientService.GetTransactionsBySku(sku);
        }

        public string Version()
        {
            _myTracing.Debug(string.Format("{0} --- {1} --- {2}", nameof(InternationalBusinessAdapter), nameof(Version), "WebApi"));
            return string.Format("{0} --- _1.0", nameof(InternationalBusinessAdapter));
        }
    }
}