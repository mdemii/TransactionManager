using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace TransactionWebApi.Controllers
{
    [ApiController]
    [Route("api/transactionstatuses")]
    public class TransactionStatusesController : ControllerBase
    {
        private ITransactionStatusManager m_transactionStatusManager;

        public TransactionStatusesController(ITransactionStatusManager transactionManager)
        {
            m_transactionStatusManager = transactionManager;
        }

        [HttpGet()]
        public async Task<IActionResult> GetTransactionStatuses()
        {
            var businessTransactionStatuses = await m_transactionStatusManager.GetAllAsync();
            //TODO: mapping businessTransactionStatuses to data transfer objects
            return Ok(businessTransactionStatuses);
        }
    }
}
