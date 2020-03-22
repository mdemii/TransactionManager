using Business.Interfaces;
using DataAccess.Models;
using DataAccess.Parameters;
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

        public Task<IEnumerable<TransactionModel>> GetAllAsync(ParametersBase parameters)
        {

            var transactionParameters = parameters as TransactionParameters;

            //TODO creaste stub repository and redirecto call there
            var statusList = new List<TransactionModel>()
            {
                new TransactionModel
                {
                    Id="Invoice0000001",
                    Amount=1000.00m,
                    Currency = new CurrencyModel
                    {
                        Id = 1,
                        Code = "USD",
                        Name = "United States Dollar",
                        Symbol = "$",
                    },
                    TransactionDate = Convert.ToDateTime("20/02/2019 12:33:16"),
                    Status = new TransactionStatusModel
                    {
                        Id = 1,
                        Name = "Approved",
                        ShortName = "A",
                    },
                },

                new TransactionModel
                {
                    Id="Invoice0000002",
                    Amount=300.00m,
                    Currency = new CurrencyModel
                    {
                        Id = 1,
                        Code = "USD",
                        Name = "United States Dollar",
                        Symbol = "$",
                    },
                    TransactionDate = Convert.ToDateTime("21/02/2019 12:33:16"),
                    Status = new TransactionStatusModel
                    {
                        Id = 3,
                        Name = "Done",
                        ShortName = "D",
                    },
                },

                new TransactionModel
                {
                    Id="Invoice0000003",
                    Amount=700.00m,
                    Currency = new CurrencyModel
                    {
                        Id = 1,
                        Code = "USD",
                        Name = "United States Dollar",
                        Symbol = "$",
                    },
                    TransactionDate = Convert.ToDateTime("22/02/2019 12:33:16"),
                    Status = new TransactionStatusModel
                    {
                        Id = 2,
                        Name = "Rejected",
                        ShortName = "R",
                    },
                },

                new TransactionModel
                {
                    Id="Invoice0000004",
                    Amount=900.00m,
                    Currency = new CurrencyModel
                    {
                        Id = 1,
                        Code = "USD",
                        Name = "United States Dollar",
                        Symbol = "$",
                    },
                    TransactionDate = Convert.ToDateTime("23/02/2019 12:33:16"),
                    Status = new TransactionStatusModel
                    {
                        Id = 1,
                        Name = "Approved",
                        ShortName = "A",
                    },
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
