using DataAccess.Models;

namespace DataAccess
{
    public interface ITransactionRepository : IRepository<TransactionModel, string>
    {
    }
}
