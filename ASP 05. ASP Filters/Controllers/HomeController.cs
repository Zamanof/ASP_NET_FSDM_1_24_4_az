using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ASP_05._ASP_Filters.Models;
using ASP_05._ASP_Filters.Filters;

namespace ASP_05._ASP_Filters.Controllers;

//[TypeFilter(typeof(ApiKeyQueryAuthorization))]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [LastEnterDate]
    public IActionResult Index()
    {
        return View();
    }
    [DateTimeExec]
    public IActionResult Privacy()
    {
        return View();
    }

    [TypeFilter(typeof(MyAuthorizationFilter))]
    public IActionResult Welcome()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
