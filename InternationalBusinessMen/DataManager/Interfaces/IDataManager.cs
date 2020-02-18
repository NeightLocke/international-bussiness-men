using InternationalBusinessDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessDataManager.Interfaces
{
    public interface IDataManager
    {
        IEnumerable<Rates> RatesList { get; set; }
        IEnumerable<Transaction> TransactionsList { get; set; }

        IEnumerable<Rates> GetRates();

        IEnumerable<Transaction> GetTransactions();

        IEnumerable<Transaction> GetTransactionsBySku(string sku);
    }
}