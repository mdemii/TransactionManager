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
            var statusList = new List<TransactionStatusModel>()
            {
                new TransactionStatusModel
                {
                    Id=1,
                    Name="Approved",
                    ShortName="A",
                },
                new TransactionStatusModel
                {
                    Id=2,
                    Name="Rejected",
                    ShortName="R",
                },
                new TransactionStatusModel
                {
                    Id=3,
                    Name="Done",
                    ShortName="D",
                },
            };

            return Task<IEnumerable<TransactionStatusModel>>.Factory.StartNew(() => statusList);
        }

        public void Update(TransactionStatusModel item)
        {
            throw new NotImplementedException();
        }
    }
}
