using Moq;
using SpeedrunComApi.Http;
using SpeedrunComApi.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpeedrunComApi.Tests
{
    public class RunsApi
    {
        private Mock<IRateLimitedRequester> _rateLimitedRequester;
        private IRateLimitedRequester _realLimitedRequester;

        public RunsApi()
        {
            _rateLimitedRequester = new Mock<IRateLimitedRequester>();
            _realLimitedRequester = new RateLimitedRequester("", new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromMinutes(1)] = 100
            });
        }

        [Fact]
        public async Task GetRunsAsync_GetList()
        {
            var client = new SpeedrunComApiClient(_realLimitedRequester);
            var runs = await client.Runs.GetRunsAsync();

            Assert.NotNull(runs.Data);
        }
    }
}
