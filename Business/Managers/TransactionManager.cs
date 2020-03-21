using Business.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class TransactionManager : ITransactionManager
    {
        public TransactionManager()
        {

        }

        public Task<IEnumerable<TransactionModel>> GetAllAsync()
        {
            //TODO creaste stub repository and redirecto call there
            var statusList = new List<TransactionModel>()
            {
                new TransactionModel
                {
                    TransactionId="Invoice0000001",
                    Amount=1000.00m,
                    CurrencyCode = "USD",
                    TransactionDate = Convert.ToDateTime("20/02/2019 12:33:16"),
                    StatusId = 0,
                },

                new TransactionModel
                {
                    TransactionId="Invoice0000002",
                    Amount=300.00m,
                    CurrencyCode = "USD",
                    TransactionDate = Convert.ToDateTime("21/02/2019 12:33:16"),
                    StatusId = 0,
                },

                new TransactionModel
                {
                    TransactionId="Invoice0000003",
                    Amount=700.00m,
                    CurrencyCode = "USD",
                    TransactionDate = Convert.ToDateTime("22/02/2019 12:33:16"),
                    StatusId = 0,
                },

                new TransactionModel
                {
                    TransactionId="Invoice0000004",
                    Amount=900.00m,
                    CurrencyCode = "USD",
                    TransactionDate = Convert.ToDateTime("23/02/2019 12:33:16"),
                    StatusId = 0,
                },
            };

            return Task<IEnumerable<TransactionModel>>.Factory.StartNew(() => statusList);
        }

        public void AddTransactions(IEnumerable<TransactionModel> transactions)
        {
            throw new NotImplementedException();
        }
    }
}
