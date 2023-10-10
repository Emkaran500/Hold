using Hold.Mediator;
using Hold.Mediator.Base;
using Hold.Models;
using Hold.Repositories;
using Hold.Repositories.Base;
using Hold.ViewModels;
using Hold.ViewModels.Base;
using SimpleInjector;
using System.Windows;
using System.Linq;
using Microsoft.Data.SqlClient;
using Dapper;
using System.IO;

namespace Hold
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; } = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {
            this.RegisterContainer();
            this.Start<HomeViewModel>();
            base.OnStartup(e);
        }

        private void Start<T>() where T : ViewModelBase
        {
            var mainView = new MainWindow();

            var mainViewModel = Container.GetInstance<MainViewModel>();
            mainViewModel.ActiveViewModel = Container.GetInstance<T>();

            mainView.DataContext = mainViewModel;

            SqlConnection sqlConnection = new SqlConnection("Server=localhost;Database=HoldDb;User Id=myUsername;Password=myPassword;TrustServerCertificate=True;");
            sqlConnection.Open();
            string sql = File.ReadAllText("\\Sql\\sql.sql");
            sqlConnection.Execute(sql);

            mainView.ShowDialog();
        }

        private void RegisterContainer()
        {
            Container.RegisterSingleton<User>();
            Container.RegisterSingleton<Basket>();
            Container.RegisterSingleton<IMessenger, MediatorMVVM>();
            Container.RegisterSingleton<IUserRepository, UserEFRepository>();
            Container.RegisterSingleton<IRestaurantRepository, RestaurantEFRepository>();
            Container.RegisterSingleton<IProductRepository, ProductEFRepository>();
            Container.RegisterSingleton<IOrderRepository, OrderEFRepository>();

            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<HomeViewModel>();
            Container.RegisterSingleton<ProfileViewModel>();
            Container.RegisterSingleton<MakeOrderViewModel>();
            Container.RegisterSingleton<BasketViewModel>();
            Container.RegisterSingleton<YourOrdersViewModel>();

            Container.Verify();
        }
    }
}
