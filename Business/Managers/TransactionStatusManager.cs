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

        ITransactionStatusRepository m_statusRepository;

        public TransactionStatusManager(ITransactionStatusRepository transactionStatusRepository)
        {
            m_statusRepository = transactionStatusRepository;
        }

        public async Task<IEnumerable<TransactionStatusModel>> GetAllAsync(ParametersBase parameters = null)
        {
            var transactionStatuses = await m_statusRepository.GetAllAsync(parameters);
            return transactionStatuses;
        }
    }
}
