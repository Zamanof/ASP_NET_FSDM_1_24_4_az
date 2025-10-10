using ASP_22._Background_Workers.DTOs;
using ASP_22._Background_Workers.Hosted_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_22._Background_Workers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly MessageQueue _messageQueue;

        public TransactionController(ILogger<TransactionController> logger, 
            MessageQueue messageQueue)
        {
            _logger = logger;
            _messageQueue = messageQueue;
        }
        [HttpPost]
        public async Task<ActionResult> CreateTransaction(CreateTransactionRequest request)
        {
            _messageQueue.Enqueue(request);

            //await Task.Run(async () =>
            //{
            //    _logger.LogError("Transaction Begin!!!");
            //    await Task.Delay(10000);
            //    _logger.LogError("Transaction End!!!");
            //});
            return Ok();
        }
    }
}
