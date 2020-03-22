using Business.Interfaces;
using DataAccess.Models;
using DataAccess.Parameters;
using DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class TransactionStatusManager : ITransactionStatusManager
    {

        ITransactionStatusRepository m_repository;

        public TransactionStatusManager(ITransactionStatusRepository repository)
        {
            m_repository = repository;
        }

        public async Task<IEnumerable<TransactionStatusModel>> GetAllAsync(ParametersBase parameters = null)
        {
            var transactionStatuses = await m_repository.GetAllAsync(parameters);
            return transactionStatuses;
        }
    }
}
