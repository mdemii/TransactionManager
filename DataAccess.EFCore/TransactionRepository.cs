using DataAccess.Models;
using DataAccess.Parameters;
using System;
using System.Collections.Generic;

namespace DataAccess.EFCore
{
    public class TransactionRepository : IRepository<TransactionModel, string>
    {
        public IEnumerable<TransactionModel> GetAll(ParametersBase parameters = null)
        {
            throw new NotImplementedException();
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
