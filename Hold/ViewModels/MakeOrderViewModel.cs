using Hold.Models;
using Hold.Repositories.Base;
using Hold.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Hold.ViewModels;

public class MakeOrderViewModel : ViewModelBase
{
    private readonly IRestaurantRepository restaurantRepository;
    public ObservableCollection<Restaurant> Restaurants { get; set; } = new ObservableCollection<Restaurant>();

    public MakeOrderViewModel(IRestaurantRepository restaurantRepository)
    {
        this.restaurantRepository = restaurantRepository;

        foreach (var restaurant in restaurantRepository.GetAll())
        {
            var enviroment = System.Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            projectDirectory = projectDirectory.Remove(projectDirectory.ToCharArray().Length - 4);

            restaurant.TextureBrush.ImageSource = new BitmapImage(new Uri($"{projectDirectory + restaurant.Texture}", UriKind.Absolute));
            this.Restaurants.Add(restaurant);
        }
    }


}
