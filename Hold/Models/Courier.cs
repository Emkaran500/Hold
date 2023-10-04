using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hold.Models;

[Table("Couriers")]
public class Courier
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string? FullName { get; set; }

    [Column(name: "Phone Number")]
    [Phone]
    public string? PhoneNumber { get; set; }
    public int? Distance { get; set; }

    [Column(name: "Time Left")]
    public TimeOnly? TimeForDelivery { get; set; }
}
