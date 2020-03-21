using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace DataAccess
{
    public interface ITransactionRepository : IRepository<Transaction, string>
    {
    }
}
