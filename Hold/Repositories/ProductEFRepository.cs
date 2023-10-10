using Hold.Data;
using Hold.Models;
using Hold.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace Hold.Repositories;

public class ProductEFRepository : IProductRepository
{
    private readonly HoldDbContext dbContext;
    public ProductEFRepository()
    {
        this.dbContext = new HoldDbContext();
    }

    public IEnumerable<Product> GetAllForRestaurant(int id)
    {
        return this.dbContext.Products.Where(p => p.RestaurantId == id).ToList();
    }

    public Product GetByName(string name)
    {
        return this.dbContext.Products.Where(p => p.ProductName == name).First();
    }
}
