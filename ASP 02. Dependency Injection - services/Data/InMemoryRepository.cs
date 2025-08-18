

using ASP_02._Dependency_Injection___services.Models;

namespace ASP_02._Dependency_Injection.Data;

public class InMemoryRepository : IProductRepository
{
    private readonly IDictionary<Guid, Product> _products = new Dictionary<Guid, Product>();
    public InMemoryRepository()
    {
        AddProduct(new Product { Name = "Sweatshirt", Description = "Qalin" });
        AddProduct(new Product { Name = "Shirt", Description = "Nazik" });
        AddProduct(new Product { Name = "T-shirt", Description = "Lap nazik" });
        AddProduct(new Product { Name = "Pant", Description = "Jeans" });
    }
    public Product AddProduct(Product product)
    {
        product.Id = Guid.NewGuid();
        _products.Add(product.Id, product);
        return product;
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products.Values;
    }
}
