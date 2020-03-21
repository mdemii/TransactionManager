using System;

namespace DataAccess.Models
{
    public class TransactionModel
    {
        /// <summary>
        /// Transaction Identificator
        /// </summary>
        public string TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string CurrencyCode { get; set; }

        /// <summary>
        /// Transaction Date - should be in the "dd/MM/yyyy hh:mm:ss" format 
        /// </summary>
        public DateTime TransactionDate { get; set; }

        public sbyte StatusId {get; set;}
    }
}
