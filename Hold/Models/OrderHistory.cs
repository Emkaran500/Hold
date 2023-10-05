using System;

namespace Hold.Models;

public class OrderHistory
{
    public int Id { get; set; }
    public Order? Order { get; set; }
    public DateTime TimeOfOrder { get; set; }
}
