using N_tier.DAL.Repositories;
using N_tier.Models.Models;

namespace N_tier.BLL.Services;
public class ProductService
{
    private readonly ProductRepository _repository;

    public ProductService(ProductRepository repository)
    {
        _repository = repository;
    }

    public List<Product> GetAllProducts()
    {
        return _repository.GetAll();
    }
}
