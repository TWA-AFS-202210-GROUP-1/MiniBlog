using System.Net;
using MiniBlog.Exceptions;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services;

public class UserService : IUserService
{
    private readonly IArticleStore _articleStore;
    private readonly IUserStore _userStore;

    public UserService(IUserStore userStore, IArticleStore articleStore)
    {
        _userStore = userStore;
        _articleStore = articleStore;
    }

    public User RegisterUser(User user)
    {
        if (!_userStore.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
        {
            _userStore.Save(user);
            return user;
        }

        throw new HttpResponseException(HttpStatusCode.BadRequest, $"User {user.Name} has already existed.");
    }

    public List<User> GetAllUsers()
    {
        return _userStore.GetAll();
    }

    public User UpdateUser(User user)
    {
        var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == user.Name);
        if (foundUser != null)
        {
            foundUser.Email = user.Email;
            return foundUser;
        }

        throw new HttpResponseException(HttpStatusCode.NotFound, $"Can not found user {user.Name}.");

    }

    public void DeleteUser(string name)
    {
        var foundUser = _userStore.GetAll().FirstOrDefault(_ => _.Name == name);
        if (foundUser == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound, $"Can not found user {name}.");
        }
        _userStore.Delete(foundUser);
        var articles = _articleStore.GetAll()
            .Where(article => article.UserName == foundUser.Name)
            .ToList();
        articles.ForEach(article => _articleStore.Delete(article));

    }

    public User GetUserByName(string name)
    {
        var foundUser =  _userStore.GetAll()
            .FirstOrDefault(_ => string.Equals(_.Name, name, StringComparison.CurrentCultureIgnoreCase));
        if (foundUser != null)
        {
            return foundUser;
        }

        throw new HttpResponseException(HttpStatusCode.NotFound, $"Can not found user {name}.");
    }
}