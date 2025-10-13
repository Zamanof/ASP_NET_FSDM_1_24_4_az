using ASP_23._Unit_Test.Data;
using Quartz;

namespace ASP_23._Unit_Test.HostedServices;

public class DatabaseClearCronJob : IJob
{
    private readonly ILogger _logger;
    private readonly IServiceProvider _serviceProvider;

    public DatabaseClearCronJob(ILogger<DatabaseClearCronJob> logger, IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ToDoContext>();
        _logger.LogError("Database clear job is running");
        _logger.LogCritical($"Todo's count = {dbContext.ToDoItems.Count()}");
    }
}
