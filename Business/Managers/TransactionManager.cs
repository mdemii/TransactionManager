using Business.Interfaces;
using DataAccess.Models;
using DataAccess.Parameters;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class TransactionManager : ITransactionManager
    {
        ITransactionRepository m_transactionRepository;

        public TransactionManager(ITransactionRepository transactionRepository)
        {
            m_transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<TransactionModel>> GetAllAsync(ParametersBase parameters)
        {
            var transactions = await m_transactionRepository.GetAllAsync(parameters);
            return transactions;
        }

        public void AddTransactions(IEnumerable<TransactionModel> transactions)
        {
            throw new NotImplementedException();
        }
    }
}
