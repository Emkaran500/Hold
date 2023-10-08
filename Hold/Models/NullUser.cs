namespace Hold.Models;

public class NullUser : User
{
    public NullUser()
    {
        this.Id = default;
        this.ProfileName = "Unknown";
        this.Balance = default;
        this.ProfilePhoneNumber = "Unknown";
        this.Email = "Unknown";
    }
}
