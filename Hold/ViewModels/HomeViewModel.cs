using Hold.Mediator.Base;
using Hold.Models;
using Hold.ViewModels.Base;

namespace Hold.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public string? ProfileName { get; set; }

    public HomeViewModel()
    {
        Country country = new Country()
        {
            Id = 1,
            CountryName = "Azerbaijan"
        };

        User user = App.Container.GetInstance<User>();
        user.Id = 1;
        user.ProfileName = "Emil";
        user.Balance = 0;
        user.ProfilePhoneNumber = "+994517608842";
        user.Email = "emkaran_500@mail.ru";
        user.Country = country;

        this.ProfileName = App.Container.GetInstance<User>().ProfileName;
    }
}
