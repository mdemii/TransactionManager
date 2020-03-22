using AutoMapper;
using DataAccess.EFCore.DbContexts;
using DataAccess.Models;
using DataAccess.Parameters;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private TransactionDbContext m_dbContext;
        private readonly IMapper m_mapper;

        public TransactionRepository(TransactionDbContext dbContext, IMapper mapper)
        {
            m_mapper = mapper;
            m_dbContext = dbContext;
        }

        public Task<IEnumerable<TransactionModel>> GetAllAsync(ParametersBase parameters = null)
        {
            var transactionEntities = m_dbContext.Transactions
                                                    .Include(t=>t.Currency)
                                                    .Include(t=>t.TransactionStatus)
                                                    .AsQueryable();

            if (parameters != null)
            {
                var pageNumber = parameters.PageNumber;
                var pageSize = parameters.PageSize;
                var skip = (pageNumber - 1) * pageSize;
                transactionEntities = transactionEntities.Skip(skip).Take(pageSize);
            }

            var transactionParameters = parameters as TransactionParameters;

            if (transactionParameters != null)
            {
                if (!string.IsNullOrEmpty(transactionParameters.Currency))
                {
                    transactionEntities = transactionEntities.Where(t => t.Currency.Code.ToLower().Equals(transactionParameters.Currency.Trim().ToLower()));
                }

                if (!string.IsNullOrEmpty(transactionParameters.Status))
                {
                    transactionEntities = transactionEntities.Where(t => t.TransactionStatus.ShortName.ToLower().Equals(transactionParameters.Status.Trim().ToLower()));
                }

                if (transactionParameters.StartDate.HasValue &&
                    transactionParameters.EndDate.HasValue)
                {
                    transactionEntities = transactionEntities.Where(t => t.TransactionDate >= transactionParameters.StartDate &&
                                                                         t.TransactionDate <= transactionParameters.EndDate);
                }

            }


            var transactionModels = m_mapper.Map<IEnumerable<TransactionModel>>(transactionEntities);
            return Task<IEnumerable<TransactionModel>>.Factory.StartNew(() => transactionModels);
        }

        public TransactionModel Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Create(TransactionModel item)
        {
            throw new NotImplementedException();
        }

        public void Update(TransactionModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
