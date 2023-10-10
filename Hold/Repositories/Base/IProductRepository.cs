using Hold.Models;
using System.Collections.Generic;

namespace Hold.Repositories.Base;

public interface IProductRepository
{
    public IEnumerable<Product> GetAll();
}
