using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hold.Models;

public class Basket
{
    public ObservableCollection<Product> BasketProducts { get; set; }
}
