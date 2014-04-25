namespace AutofixtureSample
{
    public class AccountManager
    {
        private readonly IRepository repository;
        private readonly IUserProvider userProvider;

        public AccountManager(IRepository repository, IUserProvider userProvider)
        {
            this.repository = repository;
            this.userProvider = userProvider;
        }

        public void RegisterUser(string login, string password)
        {
            var user = userProvider.GetUserByName(login);
            if (user == null)
                repository.SaveUser(new User{Name = login});
        }
    }

    public class User
    {
        public string Name { get; set; }
    }

    public interface IUserProvider
    {
        User GetUserByName(string name);
    }

    public interface IRepository
    {
        void SaveUser(User user);
    }
}
