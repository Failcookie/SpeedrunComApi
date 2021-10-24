using Moq;
using SpeedrunComApi.Http;
using SpeedrunComApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SpeedrunComApi.Tests
{
    public class UsersApi
    {
        private Mock<IRateLimitedRequester> _rateLimitedRequester;
        private IRateLimitedRequester _realLimitedRequester;

        public UsersApi()
        {
            _rateLimitedRequester = new Mock<IRateLimitedRequester>();
            _realLimitedRequester = new RateLimitedRequester("", new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromMinutes(1)] = 100
            });
        }

        [Fact]
        public async Task GetUsersAsync_GetListOfUsers()
        {
            var client = new SpeedrunComApiClient(_rateLimitedRequester.Object);
            var users = await client.Users.GetUsersAsync();

            Assert.NotNull(users);
        }

        [Fact]
        public async Task GetUserByIdAsync_GetPac()
        {
            var client = new SpeedrunComApiClient(_realLimitedRequester);
            var user = await client.Users.GetUserbyId("wzx7q875");

            Assert.NotNull(user.Data);
        }
    }
}
