using Hold.Models;
using Hold.Repositories.Base;
using Hold.ViewModels.Base;
using System.Collections.ObjectModel;

namespace Hold.ViewModels;

public class ProfileViewModel : ViewModelBase
{
    private readonly IUserRepository productRepository;
    public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

    public ProfileViewModel(IUserRepository productRepository)
    {
        this.productRepository = productRepository;
        this.Users.Add(App.Container.GetInstance<User>());
    }
}
