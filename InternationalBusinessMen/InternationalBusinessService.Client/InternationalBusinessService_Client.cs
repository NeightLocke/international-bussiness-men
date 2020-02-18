using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternationalBusinessDTOs;

namespace InternationalBusinessService.Client
{
    public class InternationalBusinessService_Client : InternationalBusinessServiceLibrary.Interfaces.IInternationalBusinessService
    {
        private readonly InternationalBusinessService.Client.InternationalBusinessService_Client_1_0.IInternationalBusinessService _clientService;

        public InternationalBusinessService_Client(string endpointName, string remoteAddress)
        {
            if (endpointName == null)
            {
                _clientService = new InternationalBusinessService.Client.InternationalBusinessService_Client_1_0.InternationalBusinessServiceClient();
            }
            else
            {
                if (remoteAddress == null)
                {
                    _clientService =
                        new InternationalBusinessService.Client.InternationalBusinessService_Client_1_0.InternationalBusinessServiceClient(endpointName);
                }
                else
                {
                    _clientService =
                        new InternationalBusinessService.Client.InternationalBusinessService_Client_1_0.InternationalBusinessServiceClient(endpointName, remoteAddress);
                }
            }
        }

        public IEnumerable<Rates> GetRates()
        {
            return _clientService.GetRates();
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _clientService.GetTransactions();
        }

        public IEnumerable<Transaction> GetTransactionsBySku(string sku)
        {
            return _clientService.GetTransactionsBySku(sku);
        }
    }
}