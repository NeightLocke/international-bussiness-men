using InternationalBusinessDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessServiceLibrary.Interfaces
{
    [ServiceContract]
    public interface IInternationalBusinessService
    {
        [OperationContract]
        IEnumerable<Rates> GetRates();

        [OperationContract]
        IEnumerable<Transaction> GetTransactions();

        [OperationContract]
        IEnumerable<Transaction> GetTransactionsBySku(string sku);
    }
}