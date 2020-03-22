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
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly IMapper m_mapper;
        private TransactionDbContext m_dbContext;

        public CurrencyRepository(TransactionDbContext dbContext, IMapper mapper)
        {
            m_mapper = mapper;
            m_dbContext = dbContext;
        }

        public void Create(CurrencyModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(sbyte id)
        {
            throw new NotImplementedException();
        }

        public CurrencyModel Get(sbyte id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CurrencyModel>> GetAllAsync(ParametersBase parameters = null)
        {
            var statusEntities = m_dbContext.Currencies.AsQueryable();
            var statusModels = m_mapper.Map<IEnumerable<CurrencyModel>>(statusEntities);
            return Task<IEnumerable<CurrencyModel>>.Factory.StartNew(() => statusModels);
        }

        public void Update(CurrencyModel item)
        {
            throw new NotImplementedException();
        }
    }
}
