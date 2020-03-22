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
        ITransactionRepository m_repository;

        public TransactionManager(ITransactionRepository repository)
        {
            m_repository = repository;
        }

        public async Task<IEnumerable<TransactionModel>> GetAllAsync(ParametersBase parameters)
        {
            var transactions = await m_repository.GetAllAsync(parameters);
            return transactions;
        }

        public void AddTransactions(IEnumerable<TransactionModel> transactions)
        {
            throw new NotImplementedException();
        }
    }
}
