using Hold.Data;
using Hold.Models;
using Hold.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace Hold.Repositories;

public class OrderEFRepository : IOrderRepository
{
    private readonly HoldDbContext dbContext;
    public OrderEFRepository()
    {
        this.dbContext = new HoldDbContext();
    }

    public void Add(Order order)
    {
        this.dbContext.Orders.Add(order);
        this.dbContext.SaveChanges();
    }

    public IEnumerable<Order> GetAll()
    {
        return this.dbContext.Orders.ToList();
    }
}
