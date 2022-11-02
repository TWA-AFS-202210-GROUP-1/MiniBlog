using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Services;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        //private IArticleStore _articleStore;
        //private IUserStore _userStore;
        private IUserService _userService;

        //public UserController(IArticleStore articleStore, IUserStore userStore, IUserService userService)
        public UserController(IUserService userService)
        {
            //_articleStore = articleStore;
            //_userStore = userStore;
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<User> Register([FromBody] User user)
        {
            return Created("/user", _userService.Register(user));
        }

        [HttpGet]
        public List<User> GetAll()
        {
            //return _userStore.GetAll();
            return _userService.GetAll();
        }

        [HttpPut]
        public User Update(User user)
        {

            //var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == user.Name);
            //if (foundUser != null)
            //{
            //    foundUser.Email = user.Email;
            //}

            //return foundUser;
            return _userService.Update(user);
        }

        [HttpDelete]
        public User Delete(string name)
        {
            //var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == name);
            //if (foundUser != null)
            //{
            //    _userStore.Delete(foundUser);
            //    var articles = _articleStore.GetAll()
            //        .Where(article => article.UserName == foundUser.Name)
            //        .ToList();
            //    articles.ForEach(article => _articleStore.Delete(article));
            //}

            //return foundUser;
            return _userService.Delete(name);
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            //return _userStore.GetAll().FirstOrDefault(_ =>
            //    string.Equals(_.Name, name, StringComparison.CurrentCultureIgnoreCase)) ?? throw new
            //    InvalidOperationException();
            return _userService.GetByName(name);
        }
    }
}