using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface ITransactionManager : IManager<TransactionModel>
    {
        void AddTransactions(IEnumerable<TransactionModel> transactions);
    }
}
