using Moq;
using SpeedrunComApi.Http;
using SpeedrunComApi.Interfaces;
using SpeedrunComApi.Models.Users;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace SpeedrunComApi.Tests
{
    public class GuestsApi
    {
        private Mock<IRateLimitedRequester> _rateLimitedRequester;
        private IRateLimitedRequester _realLimitedRequester;

        public GuestsApi()
        {
            _rateLimitedRequester = new Mock<IRateLimitedRequester>();
            _realLimitedRequester = new RateLimitedRequester("", new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromMinutes(1)] = 100
            });
        }

        [Theory]
        [InlineData("Alex")]
        public async Task GetGuests_NoGuestFound(string name)
        {
            try
            {
                var client = new SpeedrunComApiClient(_realLimitedRequester);
                var user = await client.Guests.GetGuestByName(name);
            }
            catch (SpeedrunComApiException ex)
            {
                Assert.True(ex.HttpStatusCode == HttpStatusCode.NotFound);
            }
        }
    }
}
