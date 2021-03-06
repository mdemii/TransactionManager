﻿using System;

namespace DataAccess.Models
{
    public class TransactionModel
    {
        /// <summary>
        /// Transaction Identificator
        /// </summary>
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public CurrencyModel Currency { get; set; }

        /// <summary>
        /// Transaction Date - should be in the "dd/MM/yyyy hh:mm:ss" format 
        /// </summary>
        public DateTime TransactionDate { get; set; }

        public TransactionStatusModel Status {get; set;}
    }
}
