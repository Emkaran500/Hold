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
using System.Linq;
using Hold.Data;

namespace Hold.ViewModels;

public class MakeOrderViewModel : ViewModelBase
{
    private readonly IRestaurantRepository restaurantRepository;
    private readonly IProductRepository productRepository;
    private readonly HoldDbContext dbContext;
    public ObservableCollection<Restaurant> Restaurants { get; set; } = new ObservableCollection<Restaurant>();
    public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();
    public int currentRestaurantId = 1;

    public MakeOrderViewModel(IRestaurantRepository restaurantRepository, IProductRepository productRepository)
    {
        this.dbContext = new HoldDbContext();
        this.restaurantRepository = restaurantRepository;
        this.productRepository = productRepository;
        var enviroment = System.Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
        projectDirectory = projectDirectory.Remove(projectDirectory.ToCharArray().Length - 4);

        SqlConnection sqlConnection = new SqlConnection("Server=localhost;Database=HoldDb;User Id=admin;Password=admin;");
        sqlConnection.Open();
        if (this.dbContext.Restaurants.Any() == false && this.dbContext.Products.Any() == false)
        {
            string sql = File.ReadAllText($"{projectDirectory}\\Sql\\insert.sql");
            sqlConnection.Execute(sql);
        }


        foreach (var restaurant in restaurantRepository.GetAll())
        {

            restaurant.TextureBrush = new BitmapImage(new Uri($"{projectDirectory + restaurant.Texture}", UriKind.Absolute));
            this.Restaurants.Add(restaurant);
        }

        foreach (var product in productRepository.GetAllForRestaurant(this.currentRestaurantId))
        {

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
