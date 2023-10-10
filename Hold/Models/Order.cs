using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hold.Models;

public class Order
{
    public int Id { get; set; }
    public double? Sum { get; set; }
    public ObservableCollection<Product>? Product { get; set; }
}
