using Hold.Commands.Base;
using Hold.Models;
using Hold.Repositories;
using Hold.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Hold.ViewModels;

public class BasketViewModel : ViewModelBase
{
    public Basket Basket { get; set; }
    public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

    public BasketViewModel()
    {
        this.Basket = App.Container.GetInstance<Basket>();
        this.Products = this.Basket.BasketProducts;
    }

    private CommandBase deleteCommand;
    public CommandBase DeleteCommand => this.deleteCommand ??= new CommandBase
        (
            execute: () =>
            {
                if (this.Products != null)
                {
                    this.Basket.BasketProducts.Clear();
                    this.Products.Clear();
                }
            },
            canExecute: () => true
        );
    private CommandBase refreshCommand;
    public CommandBase RefreshCommand => this.refreshCommand ??= new CommandBase
        (
            execute: () =>
            {
                this.Basket = App.Container.GetInstance<Basket>();
                this.Products = this.Basket.BasketProducts;
            },
            canExecute: () => true
        );
    private CommandBase buyCommand;
    public CommandBase BuyCommand => this.buyCommand ??= new CommandBase
        (
            execute: () =>
            {
                double? sum = this.Products.Sum(p => p.Price);
                if (App.Container.GetInstance<User>().Balance < sum)
                {
                    MessageBox.Show($"You don't have enough balance! {App.Container.GetInstance<User>().Balance < sum}");
                }
                else
                {
                    OrderEFRepository orderRepository = new OrderEFRepository();
                    orderRepository.Add(new Order()
                    {
                        Product = this.Products,
                        Sum = sum
                    });
                    App.Container.GetInstance<User>().Balance -= sum;
                    MessageBox.Show("Transaction Successfull!");
                }
            },
            canExecute: () => true
        );
}
