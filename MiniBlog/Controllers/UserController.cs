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
        private IUserStore _userStore;
        private IArticleStore _articleStore;
        private IUserService _userService;

        public UserController(IUserStore userStore, IArticleStore articleStore, IUserService userService)
        {
            _userStore = userStore;
            _articleStore = articleStore;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            var registeredUser = _userService.RegisterUser(user);
            if (registeredUser == null)
            {
                return BadRequest();
            }

            return Created($"user/{registeredUser.Name}", registeredUser);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            var foundUser = _userService.Update(user);
            if (foundUser ==null)
            {
                return NotFound();
            }

            return Ok(foundUser);
        }

        [HttpDelete]
        public User Delete(string name)
        {
            var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == name);
            if (foundUser != null)
            {
                _userStore.Delete(foundUser);
                var articles = _articleStore.GetAll()
                    .Where(article => article.UserName == foundUser.Name)
                    .ToList();
                articles.ForEach(article => _articleStore.Delete(article));
            }

            return foundUser;
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return _userStore.GetAll().FirstOrDefault(_ =>
                string.Equals(_.Name, name, StringComparison.CurrentCultureIgnoreCase)) ?? throw new
                InvalidOperationException();
        }
    }
}