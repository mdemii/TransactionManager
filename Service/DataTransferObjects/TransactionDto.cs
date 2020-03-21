using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DataTransferObjects
{
    public class TransactionDto
    {
        public string Id { get; set; }

        public string Payment { get; set; }

        public string Status { get; set; }
    }
}
