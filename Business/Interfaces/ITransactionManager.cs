using DataAccess.Models;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface ITransactionManager : IManager<TransactionModel>
    {
        void AddTransactions(IEnumerable<TransactionModel> transactions);
    }
}
