using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Parameters
{
    public class ParametersBase
    {
        const int MAX_PAGE_SIZE = 30;

        private int m_pageSize = 10;

        public int PageNumber { get; set; } = 1;

        public int PageSize 
        {
            get => m_pageSize;
            set => m_pageSize = (value > MAX_PAGE_SIZE) ? MAX_PAGE_SIZE : value;
        }
    }
}
