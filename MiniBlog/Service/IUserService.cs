using MiniBlog.Model;

namespace MiniBlog.Service
{
    public interface IUserService
    {
        User Delete(string name);
        List<User> GetAll();
        User GetByName(string name);
        User Register(User user);
        User Update(User user);
    }
}