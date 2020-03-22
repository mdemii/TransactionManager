using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace TransactionWebApi.Controllers
{
    [ApiController]
    [Route("api/currencies")]
    public class CurrencyController : ControllerBase
    {
        private ICurrencyManager m_manager;

        public CurrencyController(ICurrencyManager manager)
        {
            m_manager = manager;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCurrency()
        {
            var businessCurrency = await m_manager.GetAllAsync();
            return Ok(businessCurrency);
        }
    }
}
