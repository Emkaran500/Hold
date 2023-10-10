using Hold.Models;
using Hold.Repositories.Base;
using Hold.ViewModels.Base;
using System.Collections.ObjectModel;

namespace Hold.ViewModels;

public class YourOrdersViewModel : ViewModelBase
{
    private readonly IOrderRepository orderRepository;
    public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();

    public YourOrdersViewModel(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;

        foreach (var order in this.orderRepository.GetAll())
        {
            this.Orders.Add(order);
        }
    }


}
