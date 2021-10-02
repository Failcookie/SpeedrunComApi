using System;
using System.Threading.Tasks;
using Xunit;

namespace SpeedrunComApi.Tests
{
    public class UsersApi
    {
        [Fact]
        public async Task GetUsersAsync_GetListOfUsers()
        {
            var client = new SpeedrunComApiClient();
            var users = await client.Users.GetUsersAsync();

            Assert.NotNull(users);
        }
    }
}
