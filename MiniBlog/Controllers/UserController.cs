using Microsoft.AspNetCore.Identity;
using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Service;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IArticleStore articleStore;
        private IUserStore userStore;
        private IUserService userService;

        public UserController(IArticleStore articleStore, IUserStore userStore, IUserService userService)
        {
            this.articleStore = articleStore;
            this.userStore = userStore;
            this.userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Register(User user)
        {
            return Created(" ", userService.Register(user));
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
            return userStore.GetAll().FirstOrDefault(_ =>
                string.Equals(_.Name, name, StringComparison.CurrentCultureIgnoreCase)) ?? throw new
                InvalidOperationException();
        }
    }
}