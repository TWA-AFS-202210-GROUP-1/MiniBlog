using MiniBlog.Model;
using MiniBlog.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniBlog.Service
{
    public class UserService : IUserService
    {
        private IArticleStore articleStore;
        private IUser userStore;

        public UserService(IArticleStore articleStore, IUser userStore)
        {
            this.articleStore = articleStore;
            this.userStore = userStore;
        }

        public List<User> GetAll()
        {
            return userStore.GetAll();
        }

        public User Register(User user)
        {
            if (!userStore.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
            {
                userStore.Save(user);
            }

            return user;
        }
    }
}
