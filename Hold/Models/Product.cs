using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media;

namespace Hold.Models;

public class Product
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public double? Price { get; set; }
    public bool? LeftInStock { get; set; }
    public Restaurant Restaurant { get; set; }
    public int? RestaurantId { get; set; }
    public string? Texture { get; set; }
    [NotMapped]
    public ImageBrush TextureBrush { get; set; } = new ImageBrush();
}
