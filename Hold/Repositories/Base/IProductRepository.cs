using Hold.Models;
using System.Collections.Generic;

namespace Hold.Repositories.Base;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllForRestaurant(int id);
    public Product GetByName(string name);
}
