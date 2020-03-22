using DataAccess.Models;

namespace DataAccess.Repositories
{
    public interface ITransactionRepository : IRepository<TransactionModel, string>
    {
    }
}
