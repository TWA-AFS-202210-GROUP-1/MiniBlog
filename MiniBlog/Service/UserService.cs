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
    }
}
