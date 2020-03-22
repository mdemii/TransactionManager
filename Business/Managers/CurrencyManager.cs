using Business.Interfaces;
using DataAccess.Models;
using DataAccess.Parameters;
using DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Managers
{
    public class CurrencyManager : ICurrencyManager
    {

        ICurrencyRepository m_repository;

        public CurrencyManager(ICurrencyRepository repository)
        {
            m_repository = repository;
        }

        public async Task<IEnumerable<CurrencyModel>> GetAllAsync(ParametersBase parameters = null)
        {
            var currencyes = await m_repository.GetAllAsync(parameters);
            return currencyes;
        }
    }
}
