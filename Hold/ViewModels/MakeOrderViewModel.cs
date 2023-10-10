using Dapper;
using Hold.Commands.Base;
using Hold.Models;
using Hold.Repositories.Base;
using Hold.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Hold.ViewModels;

public class MakeOrderViewModel : ViewModelBase
{
    private readonly IRestaurantRepository restaurantRepository;
    private readonly IProductRepository productRepository;
    public ObservableCollection<Restaurant> Restaurants { get; set; } = new ObservableCollection<Restaurant>();
    public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
    public int currentRestaurantId = 1;

    public MakeOrderViewModel(IRestaurantRepository restaurantRepository, IProductRepository productRepository)
    {
        SqlConnection sqlConnection = new SqlConnection("Server=localhost;Database=HoldDb;User Id=admin;Password=admin;TrustServerCertificate=True;");
        sqlConnection.Open();
        string sql = File.ReadAllText("\\Sql\\sql.sql");
        sqlConnection.Execute(sql);

        this.restaurantRepository = restaurantRepository;
        this.productRepository = productRepository;

        foreach (var restaurant in restaurantRepository.GetAll())
        {
            var enviroment = System.Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            projectDirectory = projectDirectory.Remove(projectDirectory.ToCharArray().Length - 4);

            restaurant.TextureBrush = new BitmapImage(new Uri($"{projectDirectory + restaurant.Texture}", UriKind.Absolute));
            this.Restaurants.Add(restaurant);
        }

        foreach (var product in productRepository.GetAllForRestaurant(this.currentRestaurantId))
        {
            var enviroment = System.Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            projectDirectory = projectDirectory.Remove(projectDirectory.ToCharArray().Length - 4);

            product.TextureBrush.ImageSource = new BitmapImage(new Uri($"{projectDirectory + product.Texture}", UriKind.Absolute));
            this.Products.Add(product);
        }
    }

    private CommandBase restaurantCommand;
    public CommandBase RestaurantCommand => this.restaurantCommand ??= new CommandBase
        (
            execute: () =>
            {
                if (this.currentRestaurantId + 1 > 2)
                {
                    this.currentRestaurantId = 1;
                }
                else
                    this.currentRestaurantId++;

                this.Products.Clear();
                foreach (var product in productRepository.GetAllForRestaurant(this.currentRestaurantId))
                {
                    var enviroment = System.Environment.CurrentDirectory;
                    string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
                    projectDirectory = projectDirectory.Remove(projectDirectory.ToCharArray().Length - 4);

                    product.TextureBrush.ImageSource = new BitmapImage(new Uri($"{projectDirectory + product.Texture}", UriKind.Absolute));
                    this.Products.Add(product);
                }
            },
            canExecute: () => true
        );
}
