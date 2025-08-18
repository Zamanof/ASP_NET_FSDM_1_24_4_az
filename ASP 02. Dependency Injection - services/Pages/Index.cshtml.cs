using ASP_02._Dependency_Injection.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_02._Dependency_Injection___services.Pages;

public class IndexModel : PageModel
{
    private readonly ProductService _service;

    public IndexModel(ProductService service)
    {
        _service = service;
    }

    public void OnGet()
    {
        var products = _service.GetProducts();
        ViewData["Products"] = products;
    }
}
