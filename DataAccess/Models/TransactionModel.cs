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
        public string TransactionDate { get; set; }

        public TransactionStatusModel Status {get; set;}
    }
}
