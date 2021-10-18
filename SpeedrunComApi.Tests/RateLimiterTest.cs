using SpeedrunComApi.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpeedrunComApi.Tests
{
    public class RateLimiterTest
    {
        public static readonly TimeSpan TenSeconds = TimeSpan.FromSeconds(10);
        /// <summary>
        /// Slightly more than the percentage extra delay tests tend to take.
        /// </summary>
        public const double ErrorFactor = 1.003;
        public static readonly TimeSpan ErrorDelay = TimeSpan.FromMilliseconds(100);
        public const int Limit = 10;

        internal RateLimiter RateLimiter;
        public Stopwatch Stopwatch = new Stopwatch();

        public RateLimiterTest()
        {
            RateLimiter = new RateLimiter(new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromSeconds(10)] = Limit
            });
            Stopwatch.Restart();
        }

        [Fact]
        public async Task HandleRateLimitAsync_UseTheHandleRateLimitAsync_ReturnTimeSpanZero()
        {
            await RateLimiter.HandleRateLimitAsync();
            AssertDelayed(TimeSpan.Zero);
        }

        [Fact]
        public void HandleRateLimitAsync_ThrowOnDelay_ReturnThrowsException()
        {
            var rateLimiter = new RateLimiter(new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromHours(1)] = 1
            }, true);

            var exception = Assert.Throws<AggregateException>(() =>
            {
                for (int i = 0; i < 2; i++)
                {
                    rateLimiter.HandleRateLimitAsync().Wait();
                }
            });
            Assert.IsType<SpeedrunComApiException>(exception.InnerException);
        }

        [Fact]
        public async Task HandleRateLimitAsync_NotThrowOnDelay_ReturnNoException()
        {
            var rateLimiter = new RateLimiter(new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromSeconds(1)] = 1
            });

            for (int i = 0; i < 2; i++)
            {
                await rateLimiter.HandleRateLimitAsync();
            }
        }

        private void AssertDelayed(TimeSpan expected, int i = 0)
        {
            var actual = Stopwatch.Elapsed;
            Assert.True(expected < actual,
                $"{i} too soon. Expected: {expected}. Actual: {actual}.");
            Assert.True(actual < TimeSpan.FromTicks((int)(expected.Ticks * ErrorFactor + ErrorDelay.Ticks)),
                $"{i} too late. Expected: {expected}. Actual: {actual}.");
        }
    }
}
