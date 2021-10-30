using Moq;
using SpeedrunComApi.Http;
using SpeedrunComApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SpeedrunComApi.Tests
{
    public class PlatformsApi
    {
        private Mock<IRateLimitedRequester> _rateLimitedRequester;
        private IRateLimitedRequester _realLimitedRequester;

        public PlatformsApi()
        {
            _rateLimitedRequester = new Mock<IRateLimitedRequester>();
            _realLimitedRequester = new RateLimitedRequester("", new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromMinutes(1)] = 100
            });
        }

        [Fact]
        public async Task GetAllPlatforms()
        {
            var client = new SpeedrunComApiClient(_realLimitedRequester);
            var platforms = await client.Platforms.GetAllPlatforms();

            Assert.NotNull(platforms.Data);
        }

        [Theory]
        [InlineData("lq60nl94")]
        public async Task GetPlayById_GetAndroid(string id)
        {
            var client = new SpeedrunComApiClient(_realLimitedRequester);
            var platform = await client.Platforms.GetPlatformById(id);

            Assert.True(platform.Data.Name == "Android");
        }
    }
}
