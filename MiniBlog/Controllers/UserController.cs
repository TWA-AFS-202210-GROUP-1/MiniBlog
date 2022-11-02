namespace MiniBlog.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using MiniBlog.Model;
  using MiniBlog.Service;
  using MiniBlog.Stores;

  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    private IArticleStore articleStore;
    private IUserStore userStore;
    private IUserService userService;

    public UserController(IUserService userService, IArticleStore articleStore, IUserStore userStore)
    {
      this.articleStore = articleStore;
      this.userStore = userStore;
      this.userService = userService;
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
      return Created("/user", userService.Register(user));
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