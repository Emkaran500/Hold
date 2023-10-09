namespace Hold.Models;

public class User
{
    public int Id { get; set; }
    public string ProfileName { get; set; }
    public string ProfilePassword { get; set; }
    public string? ProfilePhoneNumber { get; set; }
    public double? Balance { get; set; }
    public string? Email { get; set; }
    public int? CountryId { get; set; }
    public Country Country { get; set; }
}
