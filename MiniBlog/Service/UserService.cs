using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Service
{
    public class UserService : IUserService
    {
        private IArticleStore articleStore;
        private IUserStore userStore;

        public UserService(IArticleStore articleStore, IUserStore userStore)
        {
            this.articleStore = articleStore;
            this.userStore = userStore;
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
