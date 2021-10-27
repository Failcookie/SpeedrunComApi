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

        [Theory]
        [InlineData("98rkldx1")]
        public async Task GetUserByIdAsync_GetPac(string userId)
        {
            var client = new SpeedrunComApiClient(_realLimitedRequester);
            var user = await client.Users.GetUserbyId(userId);

            Assert.NotNull(user.Data);
        }

        [Theory]
        [InlineData("98rkldx1")]
        public async Task GetPersonalBestsByUserId_GetRyanLockwood(string userId)
        {
            var client = new SpeedrunComApiClient(_realLimitedRequester);
            var user = await client.Users.GetPersonalBestsByUserId(userId);

            Assert.NotNull(user.Data);
        }
    }
}
