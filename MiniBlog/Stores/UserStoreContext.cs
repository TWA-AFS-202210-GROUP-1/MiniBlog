namespace MiniBlog.Stores
{
    using MiniBlog.Model;

  public class UserStoreContext : IUserStore
  {
    private List<User> users = new ();

    public List<User> GetAll()
    {
      return users;
    }

    public User Save(User user)
    {
      users.Add(user);
      return user;
    }

    public bool Delete(User user)
    {
      return users.Remove(user);
    }
  }
}
