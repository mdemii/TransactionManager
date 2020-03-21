using Business;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TransactionWebApi.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class TransactionsController : ControllerBase
    {
        private ITransactionManager m_transactionManager;

        public TransactionsController(ITransactionManager transactionManager)
        {
            m_transactionManager = transactionManager;
        }

        [HttpGet()]
        public async Task<IActionResult> GetTransactions()
        {
            var businessTransactions = await m_transactionManager.GetAllAsync();

            //TODO: mapping businessTransactions to data transfer objects
            return Ok(businessTransactions);
        }
    }
}
