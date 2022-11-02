namespace MiniBlog.Service
{
  using MiniBlog.Model;
  using MiniBlog.Stores;

  public class UserService : IUserService
  {
    private IArticleStore articleStore;
    private IUserStore userStore;

    public UserService(IArticleStore articleStore, IUserStore userStore)
    {
      this.articleStore = articleStore;
      this.userStore = userStore;
    }

    public User Register(User user)
    {
      if (!userStore.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
      {
        userStore.Save(user);
      }

      return user;
    }

    public List<User> GetAll()
    {
      return userStore.GetAll();
    }
  }
}
