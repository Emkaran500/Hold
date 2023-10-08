using Hold.Models;
using Hold.Repositories.Base;
using Hold.ViewModels.Base;
using SimpleInjector;

namespace Hold.ViewModels;

public class ProfileViewModel : ViewModelBase
{
    private readonly IUserRepository productRepository;
    public User Profile { get; set; }

    public ProfileViewModel(IUserRepository productRepository)
    {
        this.productRepository = productRepository;
        this.Profile = this.productRepository.GetUserById(App.Container.GetInstance<User>().Id);
    }
}
