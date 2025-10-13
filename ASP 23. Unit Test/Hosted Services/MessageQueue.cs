using ASP_23._Unit_Test.DTOs;
using ASP_23._Unit_Test.Models;
using System.Collections.Concurrent;

namespace ASP_23._Unit_Test.Hosted_Services;

public class MessageQueue
{
    private readonly ConcurrentQueue<CreateTransactionRequest> _queue = new();
    private readonly ILogger _logger;
    private readonly IServiceProvider _serviceProvider;

    public MessageQueue(ILogger<MessageQueue> logger, 
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public async void Enqueue(CreateTransactionRequest request)
    {
        _queue.Enqueue(request);
    }

    public async Task<string> Dequeue()
    {
        _queue.TryDequeue(out var request);
        return request.Data;
      
    }
}
