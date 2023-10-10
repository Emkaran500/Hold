using Hold.Data;
using System.Linq;
using Hold.Models;
using Hold.Repositories.Base;
using System.Collections.Generic;

namespace Hold.Repositories;

public class RestaurantEFRepository : IRestaurantRepository
{
    private readonly HoldDbContext dbContext;
    public RestaurantEFRepository()
    {
        this.dbContext = new HoldDbContext();

    }

    public IEnumerable<Restaurant> GetAll()
    {
        return this.dbContext.Restaurants.ToList<Restaurant>();
    }
}
