using Hold.Data;
using Hold.Models;
using Hold.Repositories.Base;
using System.Linq;

namespace Hold.Repositories;

public class UserEFRepository : IUserRepository
{
    private readonly HoldDbContext dbContext;
    public UserEFRepository()
    {
        this.dbContext = new HoldDbContext();
    }


    public bool CheckUserExists(string name, string password)
    {
        return this.dbContext.Users.Any(u => u.ProfileName == name && u.ProfilePassword == password);
    }

    public void Delete()
    {
        User? userToDelete = this.dbContext.Users.FirstOrDefault();

        if (userToDelete != null)
        {
            this.dbContext.Remove(userToDelete);
            this.dbContext.SaveChanges();
        }
    }

    public User GetUserById(int id)
    {
        return this.dbContext.Users.FirstOrDefault(u => u.Id == id);
    }

    public void Update(int id, User? user)
    {
        if (user == null)
            return;
        else if (user.Id == default)
            user.Id = id;

        this.dbContext.Users.Update(user);
        this.dbContext.SaveChanges();
    }
}
