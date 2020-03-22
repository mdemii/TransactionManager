using DataAccess.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<TModel, TKey> 
        where TModel : class 
        where TKey : class
    {
        Task<IEnumerable<TModel>> GetAllAsync(ParametersBase parameters = null);
        TModel Get(TKey id);
        void Create(TModel item);
        void Update(TModel item);
        void Delete(TKey id);
    }
}
