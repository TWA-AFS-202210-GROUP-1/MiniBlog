using MiniBlog.Model;

namespace MiniBlog.Services
{
    public interface IUserService
    {
        public User RegisterUser(User user);
        public List<User> GetAllUsers();
        public User UpdateUser(User user);
        public void DeleteUser(string name);
        public User GetUserByName(string name);
    }
}
