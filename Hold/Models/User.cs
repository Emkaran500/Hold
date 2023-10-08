using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hold.Models;

public class User
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string? ProfileName { get; set; }
    public string ProfilePassword { get; set; }

    [Column(name: "Phone Number")]
    [Phone(ErrorMessage = "Your phone number is wrong.")]
    public string? ProfilePhoneNumber { get; set; }

    public double? Balance { get; set; }

    [EmailAddress(ErrorMessage = "Your email adress is wrong.")]
    public string? Email { get; set; }
}
