using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hold.Models;

public class Order
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Courier? Courier { get; set; }
    public ObservableCollection<Product>? Product { get; set; }
}
