using InternationalBusinessDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalBusinessWebApiLibrary.Interfaces
{
    public interface IInternationalBusinessAdapter
    {
        string Version();

        IEnumerable<Rates> GetRates();

        IEnumerable<Transaction> GetTransactions();

        IEnumerable<Transaction> GetTransactionsBySku(string sku);
    }
}