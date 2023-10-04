using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hold.Models;

public class Product
{
    public int Id { get; set; }

    [MaxLength(30)]
    public string? Name { get; set; }

    [Range(minimum: 0, maximum: 100)]
    public double? Price { get; set; }

    [Column(name: "Left in Stock")]
    public bool? LeftInStock { get; set; }
}
