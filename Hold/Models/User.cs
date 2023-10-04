using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hold.Models;

public class User
{
    [MaxLength(50)]
    public string? FullName { get; set; }

    [Column(name: "Phone Number")]
    [Phone(ErrorMessage = "Your phone number is wrong.")]
    public string? PhoneNumber { get; set; }

    public double? Balance { get; set; }

    [EmailAddress(ErrorMessage = "Your email adress is wrong.")]
    public string Email { get; set; }
}
