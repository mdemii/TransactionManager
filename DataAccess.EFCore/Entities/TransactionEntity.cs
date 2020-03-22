using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.Entities
{
    public class TransactionEntity
    {
        /// <summary>
        /// Transaction Identificator
        /// </summary>
        public string Id { get; set; }

        public sbyte CurrencyId { get; set; }

        public CurrencyEntity Currency { get; set; }

        public sbyte TransactionStatusId { get; set; }
        
        public TransactionStatusEntity TransactionStatus { get; set; }

        public decimal Amount { get; set; }
    }
}
