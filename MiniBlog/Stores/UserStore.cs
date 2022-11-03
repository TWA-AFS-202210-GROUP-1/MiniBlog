using MiniBlog.Model;

namespace MiniBlog.Stores;

public class UserStore: IUserStore
{
    private readonly List<User> _users;

    public UserStore()
    {
        _users = new List<User>();
    }

    public List<User> GetAll()
    {
        return _users;
    }

    public User Save(User user)
    {
        _users.Add(user);
        return user;
    }

    public bool Delete(User user)
    {
        return _users.Remove(user);
    }
}