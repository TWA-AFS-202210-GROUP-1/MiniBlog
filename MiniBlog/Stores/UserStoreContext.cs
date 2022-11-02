using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public class UserStoreContext : IUserStore
    {
        private List<User> users = new List<User>();

        public bool Delete(User user)
        {
            return this.users.Remove(user);
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
    }
}
