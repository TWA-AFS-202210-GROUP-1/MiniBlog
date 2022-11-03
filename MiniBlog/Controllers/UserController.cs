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
        private IUserService userService;

        public UserController(IArticleStore articleStore, IUserService userService)
        {
            this.articleStore = articleStore;
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
            return userService.Update(user);
        }

        [HttpDelete]
        public User Delete(string name)
        {
            return userService.Delete(name);
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return userService.GetByName(name);
        }
    }
}