using MiniBlog.Model;

namespace MiniBlog.Services
{
    public interface IUserService
    {
        public User? RegisterUser(User user);
    }
}
