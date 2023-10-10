using Hold.Models;
using Hold.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hold.Views
{
    /// <summary>
    /// Логика взаимодействия для MakeOrderView.xaml
    /// </summary>
    public partial class MakeOrderView : UserControl
    {
        public Basket Basket { get; set; }

        public MakeOrderView()
        {
            InitializeComponent();
        }

        private void AddProductClick(object sender, RoutedEventArgs e)
        {
            if (this.Basket == null)
            {
                this.Basket = App.Container.GetInstance<Basket>();
                this.Basket.BasketProducts = new ObservableCollection<Product>();
            }

            IProductRepository productRepository = App.Container.GetInstance<IProductRepository>();

            if (sender is Button button)
            {
                this.Basket.BasketProducts.Add(productRepository.GetByName(button.Content.ToString()));
            }
        }
    }
}
