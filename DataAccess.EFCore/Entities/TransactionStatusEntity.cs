using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.Entities
{
    public class TransactionStatusEntity
    {
        public sbyte TransactionStatusId { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Status in unified format
        /// </summary>
        public string ShortName { get; set; }
    }
}
