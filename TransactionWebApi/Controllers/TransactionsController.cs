using AutoMapper;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Service.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TransactionWebApi.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly IMapper m_mapper;
        private ITransactionManager m_transactionManager;

        public TransactionsController(ITransactionManager transactionManager, IMapper mapper)
        {
            m_mapper = mapper;
            m_transactionManager = transactionManager;
        }

        [HttpGet()]
        public async Task<IActionResult> GetTransactions()
        {
            var businessTransactions = await m_transactionManager.GetAllAsync();
            var dtoTransactions = m_mapper.Map<IEnumerable<TransactionDto>>(businessTransactions);
            return Ok(dtoTransactions);
        }
    }
}
