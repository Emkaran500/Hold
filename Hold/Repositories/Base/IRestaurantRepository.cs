using Hold.Models;
using System.Collections.Generic;

namespace Hold.Repositories.Base;

public interface IRestaurantRepository
{
    public IEnumerable<Restaurant> GetAll();
}
