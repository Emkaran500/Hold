using Hold.Repositories;
using Hold.Repositories.Base;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Hold.Models;

public class Restaurant
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Texture { get; set; }
    [NotMapped]
    public ImageBrush TextureBrush { get; set; } = new ImageBrush();
    public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

    public Restaurant()
    {
        IProductRepository productRepository = new ProductEFRepository();

        foreach (var product in productRepository.GetAll())
        {
            this.Products.Add(product);
        }
    }
}
