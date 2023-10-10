using Hold.Models;
using System.Collections.Generic;

namespace Hold.Repositories.Base;

public interface IOrderRepository
{
    public IEnumerable<Order> GetAll();
    public void Add(Order order);
}
