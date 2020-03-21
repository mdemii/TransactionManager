namespace DataAccess.Models
{
    public class TransactionStatusModel
    {
        public sbyte Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Status in unified format
        /// </summary>
        public string ShortName { get; set; }
    }
}
