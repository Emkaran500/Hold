using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media.Imaging;

namespace Hold.Models;

public class Restaurant
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string? Name { get; set; }

    [Column(name: "Image URI")]
    public BitmapImage? Avatar { get; set; }
}
