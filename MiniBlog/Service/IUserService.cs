using MiniBlog.Model;

namespace MiniBlog.Service
{
  public interface IUserService
  {
    User Register(User user);

    List<User> GetAll();
  }
}