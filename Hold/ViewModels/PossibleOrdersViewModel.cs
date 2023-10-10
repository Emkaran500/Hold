using Hold.Models;
using Hold.Repositories.Base;
using Hold.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media.Imaging;

namespace Hold.ViewModels;

public class PossibleOrdersViewModel : ViewModelBase
{
    private readonly IProductRepository productRepository;
    public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

    public PossibleOrdersViewModel(IProductRepository productRepository)
    {
        this.productRepository = productRepository;

        foreach (var product in productRepository.GetAll())
        {
            var enviroment = System.Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            projectDirectory = projectDirectory.Remove(projectDirectory.ToCharArray().Length - 4);

            product.TextureBrush.ImageSource = new BitmapImage(new Uri($"{projectDirectory + product.Texture}", UriKind.Absolute));
            this.Products.Add(product);
        }
    }
}
