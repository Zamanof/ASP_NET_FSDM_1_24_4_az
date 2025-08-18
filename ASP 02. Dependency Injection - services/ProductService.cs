using ASP_02._Dependency_Injection.Data;
using ASP_02._Dependency_Injection___services.Models;

namespace ASP_02._Dependency_Injection___services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public Product AddProduct(Product product)
    {
        return _repository.AddProduct(product);
    }

    public IEnumerable<Product> GetProducts()
    {
        return _repository.GetProducts();
    }
}
