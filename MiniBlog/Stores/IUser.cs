using MiniBlog.Model;
using System.Collections.Generic;

namespace MiniBlog.Stores
{
    public interface IUser
    {
        bool Delete(User user);
        List<User> GetAll();
        User Save(User user);
    }
}