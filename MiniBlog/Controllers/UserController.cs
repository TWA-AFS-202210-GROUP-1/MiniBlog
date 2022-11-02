using MiniBlog.Model;
using MiniBlog.Stores;
using Microsoft.AspNetCore.Mvc;

namespace MiniBlog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IArticleStore _articleStore;
        private IUserStore _userStore;

        public UserController(IArticleStore articleStore, IUserStore userStore)
        {
            this._articleStore = articleStore;
            this._userStore = userStore;
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (!this._userStore.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
            {
                this._userStore.Save(user);
            }

            return Created($"/user/{user.Name}", user);
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return this._userStore.GetAll();
        }

        [HttpPut]
        public User Update(User user)
        {
            var foundUser = this._userStore.GetAll().FirstOrDefault(_ => _.Name == user.Name);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }

        [HttpDelete]
        public User Delete(string name)
        {
            var foundUser = this._userStore.GetAll().FirstOrDefault(_ => _.Name == name);
            if (foundUser != null)
            {
                this._userStore.Delete(foundUser);
                var articles = this._articleStore.GetAll()
                    .Where(article => article.UserName == foundUser.Name)
                    .ToList();
                articles.ForEach(article => this._articleStore.Delete(article));
            }

            return foundUser;
        }

        [HttpGet("{name}")]
        public User GetByName(string name)
        {
            return this._userStore.GetAll().FirstOrDefault(_ =>
                string.Equals(_.Name, name, StringComparison.CurrentCultureIgnoreCase)) ?? throw new
                InvalidOperationException();
        }
    }
}