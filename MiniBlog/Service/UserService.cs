using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Service
{
    public class UserService : IUserService
    {
        private IArticleStore _articleStore;
        private IUserStore _userStore;

        public UserService(IArticleStore articleStore, IUserStore userStore)
        {
            _articleStore = articleStore;
            _userStore = userStore;
        }

        public List<User> GetAll()
        {
            return _userStore.GetAll();
        }

        public User Register(User user)
        {
            if (!this._userStore.GetAll().Exists(_ => user.Name.ToLower() == _.Name.ToLower()))
            {
                this._userStore.Save(user);
            }

            return user;
        }

        public User Update(User user)
        {
            var foundUser = this._userStore.GetAll().FirstOrDefault(_ => _.Name == user.Name);
            if (foundUser != null)
            {
                foundUser.Email = user.Email;
            }

            return foundUser;
        }

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

        public User GetByName(string name)
        {
            return this._userStore.GetAll().FirstOrDefault(_ =>
                            string.Equals(_.Name, name, StringComparison.CurrentCultureIgnoreCase)) ?? throw new
                            InvalidOperationException();
        }

    }
}