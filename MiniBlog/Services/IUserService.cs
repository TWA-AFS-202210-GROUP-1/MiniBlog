using MiniBlog.Model;

namespace MiniBlog.Services
{
    public interface IUserService
    {
        public User? RegisterUser(User user);
        public List<User> GetAllUsers();
        public User? Update(User user);
    }
}
