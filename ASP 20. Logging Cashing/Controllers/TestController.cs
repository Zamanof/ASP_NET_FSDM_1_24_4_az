using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace ASP_20._Logging_Cashing.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Policy = "CanTest")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private readonly IMemoryCache _memoryCache;

    public TestController(ILogger<TestController> logger, IMemoryCache memoryCache)
    {
        _logger = logger;
        _memoryCache = memoryCache;
    }

    //[ResponseCache(Duration =30)]
    [HttpGet("test")]
    public async Task<ActionResult> Test()
    {
        if (_memoryCache.TryGetValue("cashed_data", out var cashedData))
        {
            return Ok(cashedData);
        }
        else
        {
            await Task.Delay(3000);
            var data = "It Works";
            _memoryCache.Set("cashed_data", data, new MemoryCacheEntryOptions
            {
                //AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10),
                SlidingExpiration = TimeSpan.FromSeconds(5)
            });
            return Ok(data);
        }

            //await Task.Delay(3000);
            _logger.Log(LogLevel.Information, "It's ok-> 200");
        _logger.LogCritical("Uy daaa-> 555");
        _logger.LogCritical(new NullReferenceException(), "Null");
        //Log.Information("It's ok-> 200");
        return Ok("It works");
    }
}
