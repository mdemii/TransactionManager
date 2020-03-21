using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Business
{
    public interface IManager<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync();
    }
}
