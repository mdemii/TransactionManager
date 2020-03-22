using AutoMapper;
using DataAccess.EFCore.DbContexts;
using DataAccess.Models;
using DataAccess.Parameters;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repositories
{
    public class TransactionStatusRepository : ITransactionStatusRepository
    {
        private readonly IMapper m_mapper;
        private TransactionDbContext m_dbContext;

        public TransactionStatusRepository(TransactionDbContext dbContext, IMapper mapper)
        {
            m_mapper = mapper;
            m_dbContext = dbContext;
        }

        public void Create(TransactionStatusModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(sbyte id)
        {
            throw new NotImplementedException();
        }

        public TransactionStatusModel Get(sbyte id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionStatusModel>> GetAllAsync(ParametersBase parameters = null)
        {
            var statusEntities = m_dbContext.TransactionStatuses.AsQueryable();
            var statusModels = m_mapper.Map<IEnumerable<TransactionStatusModel>>(statusEntities);
            return Task<IEnumerable<TransactionStatusModel>>.Factory.StartNew(() => statusModels);
        }

        public void Update(TransactionStatusModel item)
        {
            throw new NotImplementedException();
        }
    }
}
