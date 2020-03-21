﻿using Business.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class TransactionStatusManager : ITransactionStatusManager
    {
        public Task<IEnumerable<TransactionStatusModel>> GetAllAsync()
        {
            //TODO creaste stub repository and redirecto call there
            var statusList =new List<TransactionStatusModel>()
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
    }
}