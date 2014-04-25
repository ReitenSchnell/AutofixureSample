using NSubstitute;
using Ploeh.AutoFixture.Xunit;
using Xunit.Extensions;

namespace AutofixtureSample
{
    public class AccountManagerShortTests
    {
        [Theory, NSubData]
        public void should_save_user_if_not_found(string login, string password, [Frozen]IRepository repository,
            [Frozen] IUserProvider userProvider, AccountManager accountManager)
        {
            userProvider.GetUserByName(login).Returns(null, null);

            accountManager.RegisterUser(login, password);

            repository.Received().SaveUser(Arg.Is<User>(user => user.Name == login));
        }

        [Theory, NSubData]
        public void should_not_save_user_if_found(User user, string login, string password, [Frozen]IRepository repository,
            [Frozen] IUserProvider userProvider, AccountManager accountManager)
        {
            userProvider.GetUserByName(login).Returns(user);

            accountManager.RegisterUser(login, password);

            repository.DidNotReceiveWithAnyArgs().SaveUser(null);
        }
    }
}
