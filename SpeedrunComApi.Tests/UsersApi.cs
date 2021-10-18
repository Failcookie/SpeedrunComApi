using Moq;
using SpeedrunComApi.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SpeedrunComApi.Tests
{
    public class UsersApi
    {
        private Mock<IRateLimitedRequester> _rateLimitedRequester;

        public UsersApi()
        {
            _rateLimitedRequester = new Mock<IRateLimitedRequester>();
        }

        [Fact]
        public async Task GetUsersAsync_GetListOfUsers()
        {
            var client = new SpeedrunComApiClient(_rateLimitedRequester.Object);
            var users = await client.Users.GetUsersAsync();

            Assert.NotNull(users);
        }
    }
}
