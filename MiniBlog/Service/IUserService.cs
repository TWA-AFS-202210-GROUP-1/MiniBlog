using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Service;

public interface IUserService
{
    public User Register(User user);
}