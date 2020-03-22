using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Parameters
{
    public class TransactionParameters : ParametersBase
    {
        public string Currency { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Status { get; set; }
    }
}
