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
        public string TransactionId { get; set; }

        public sbyte CurrencyId { get; set; }

        public CurrencyEntitty Currency { get; set; }

        public sbyte TransactionStatusId { get; set; }
        
        public TransactionStatusEntity TransactionStatus { get; set; }

        public decimal Amount { get; set; }
    }
}
