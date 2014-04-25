using NSubstitute;
using Xunit;

namespace AutofixtureSample
{
    public class AccountManagerLongTests
    {
        private readonly IRepository repository = Substitute.For<IRepository>();
        private readonly IUserProvider userProvider = Substitute.For<IUserProvider>();
        private readonly AccountManager accountManager;
        private const string login = "some login";
        private const string password = "some password";

        public AccountManagerLongTests()
        {
            accountManager = new AccountManager(repository, userProvider);
        }

        [Fact]
        public void should_save_user_if_not_found()
        {
            userProvider.GetUserByName(login).Returns(null, null);

            accountManager.RegisterUser(login, password);

            repository.Received().SaveUser(Arg.Is<User>(user => user.Name == login));
        }

        [Fact]
        public void should_not_save_user_if_found()
        {
            var user = new User {Name = "some name"};
            userProvider.GetUserByName(login).Returns(user);

            accountManager.RegisterUser(login, password);

            repository.DidNotReceiveWithAnyArgs().SaveUser(null);
        }
    }
}