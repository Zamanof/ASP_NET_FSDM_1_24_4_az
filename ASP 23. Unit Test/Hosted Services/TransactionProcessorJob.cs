
namespace ASP_23._Unit_Test.Hosted_Services;

public class TransactionProcessorJob : IHostedService
{
    private readonly ILogger _logger;
    private readonly MessageQueue _messageQueue;
    private bool _run;
    public TransactionProcessorJob(
        ILogger<TransactionProcessorJob> logger,
        MessageQueue messageQueue)
    {
        _logger = logger;
        _messageQueue = messageQueue;
    }

    private async Task Run()
    {
        while (_run)
        {
            var transaction = await _messageQueue.Dequeue();
            if (transaction is not null)
            {
                _logger.LogCritical("Transaction {Data} Started", transaction);

                await Task.Delay(TimeSpan.FromSeconds(30));

                _logger.LogCritical("Transaction {Data} Finished", transaction);
            }
        }


    }
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _run = true;
        Run();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _run = false;
        return Task.CompletedTask;
    }
}
