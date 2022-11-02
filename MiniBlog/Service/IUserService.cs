using MiniBlog.Model;
using System.Collections.Generic;

namespace MiniBlog.Service
{
    public interface IUserService
    {
        List<User> GetAll();
    }
}