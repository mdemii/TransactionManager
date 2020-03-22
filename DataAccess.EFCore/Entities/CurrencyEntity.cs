using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EFCore.Entities
{
    public class CurrencyEntity
    {
        public sbyte Id { get; set; }

        /// <summary>
        /// Example: United States Dollar
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Example: USD
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Example: $
        /// </summary>
        public string Symbol { get; set; }
    }
}
