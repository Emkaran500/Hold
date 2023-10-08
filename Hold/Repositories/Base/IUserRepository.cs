using Hold.Models;

namespace Hold.Repositories.Base;

public interface IUserRepository
{
    public bool CheckUserExists(string name, string password);
    public User GetUserById(int id);
    public void Update(int id, User user);
    public void Delete();
}
