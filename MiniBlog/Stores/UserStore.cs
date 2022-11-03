using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public class UserStore : IUserStore
    {
        private List<User> users;

        public UserStore()
        {
            this.users = new List<User>();
        }

        public List<User> GetAll()
        {
            return this.users;
        }

        public User Save(User user)
        {
            this.users.Add(user);
            return user;
        }

        public bool Delete(User user)
        {
            return this.users.Remove(user);
        }
    }
}
