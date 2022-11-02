using MiniBlog.Model;

namespace MiniBlog.Services
{
    public interface IUserService
    {
        public User? RegisterUser(User user);
        public List<User> GetAllUsers();
        public User? UpdateUser(User user);
        public bool DeleteUser(string name);
        public User? GetUserByName(string name);
    }
}
