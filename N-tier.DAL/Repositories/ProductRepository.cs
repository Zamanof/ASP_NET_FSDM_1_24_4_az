using N_tier.Data.Data;
using N_tier.Models.Models;

namespace N_tier.DAL.Repositories;

public class ProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }
}
