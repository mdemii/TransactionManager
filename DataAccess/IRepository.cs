using DataAccess.Parameters;
using System.Collections.Generic;

namespace DataAccess
{
    public interface IRepository<TModel, TKey> 
        where TModel : class 
        where TKey : class
    {
        IEnumerable<TModel> GetAll(ParametersBase parameters = null);
        TModel Get(TKey id);
        void Create(TModel item);
        void Update(TModel item);
        void Delete(TKey id);
    }
}
