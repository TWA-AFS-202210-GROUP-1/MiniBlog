using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MiniBlog.Service;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IArticleStore articleStore = new ArticleStoreContext();
        private IUser userStore = new UserContext();
        private IUserService userService;

        public UserController(IArticleStore articleStore, IUser userStore, IUserService userService)
        {
            this.articleStore = articleStore;
            this.userStore = userStore;
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (!userService.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
            {
                userService.Register(user);
            }

            return Created("/user", user);
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return userService.GetAll();
        }

        [HttpPut]
        public User Update(User user)
        {
            var foundUser = userStore.GetAll().FirstOrDefault(_ => _.Name == user.Name);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }

        [HttpDelete]
        public User Delete(string name)
        {
            var foundUser = userStore.GetAll().FirstOrDefault(_ => _.Name == name);
            if (foundUser != null)
            {
                userStore.Delete(foundUser);
                var articles = articleStore.GetAll()
                    .Where(article => article.UserName == foundUser.Name)
                    .ToList();
                articles.ForEach(article => articleStore.Delete(article));
            }

            return foundUser;
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return userStore.GetAll().FirstOrDefault(_ =>
                string.Equals(_.Name, name, StringComparison.CurrentCultureIgnoreCase)) ?? throw new
                InvalidOperationException();
        }
    }
}