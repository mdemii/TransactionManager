using DataAccess.Models;

namespace DataAccess.Repositories
{
    public interface ITransactionStatusRepository : IRepository<TransactionStatusModel, sbyte>
    {
    }
}
