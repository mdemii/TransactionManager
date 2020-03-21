using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface IManager<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAllAsync();
    }
}
