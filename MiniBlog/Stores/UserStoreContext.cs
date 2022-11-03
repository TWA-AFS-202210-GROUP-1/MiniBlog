using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public class UserStoreContext : IUserStore
    {
        private List<User> users = new List<User>();

        bool IUserStore.Delete(User user)
        {
            return this.users.Remove(user);
        }

        List<User> IUserStore.GetAll()
        {
            return this.users;
        }

        User IUserStore.Save(User user)
        {
            this.users.Add(user);
            return user;
        }
    }
}