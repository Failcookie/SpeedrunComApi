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
    public class GamesApi
    {
        private Mock<IRateLimitedRequester> _rateLimitedRequester;
        private IRateLimitedRequester _realLimitedRequester;
        private const string GameListResponsePath = "./Responses/GameList_Response.txt";
        private const string GameBulkResponsePath = "./Responses/GameBulk_Response.txt";
        private const string GameSingleResponsePath = "./Responses/GameSingle_Response.txt";
        private const string GameCategoryResponsePath = "./Responses/GameCategory_Response.txt";

        public GamesApi()
        {
            _rateLimitedRequester = new Mock<IRateLimitedRequester>();
            _realLimitedRequester = new RateLimitedRequester("", new Dictionary<TimeSpan, int>
            {
                [TimeSpan.FromMinutes(1)] = 100
            });
        }

        [Fact]
        public async Task GetGamesAsync_GetListOfGames()
        {
            _rateLimitedRequester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(File.ReadAllText(GameListResponsePath));

            var client = new SpeedrunComApiClient(_rateLimitedRequester.Object);
            var games = await client.Games.GetGamesAsync();

            Assert.NotNull(games.Data);
        }

        [Fact]
        public async Task GetGamesBulkAsync_GetDefault100Games()
        {
            _rateLimitedRequester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(File.ReadAllText(GameBulkResponsePath));

            var client = new SpeedrunComApiClient(_rateLimitedRequester.Object);
            var games = await client.Games.GetGamesBulkAsync();

            Assert.True(games.Data.Count == 100);
        }

        [Fact]
        public async Task GetGame_SuperMario64()
        {
            _rateLimitedRequester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(File.ReadAllText(GameSingleResponsePath));

            var client = new SpeedrunComApiClient(_rateLimitedRequester.Object);
            var game = await client.Games.GetGameAsync("o1y9wo6q");

            Assert.NotNull(game.Data);
        }

        [Fact]
        public async Task GetGameCategories_SuperMario64Categories()
        {
            _rateLimitedRequester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(File.ReadAllText(GameCategoryResponsePath));

            var client = new SpeedrunComApiClient(_rateLimitedRequester.Object);
            var categories = await client.Games.GetGameGategoriesAsync("o1y9wo6q", false);

            Assert.NotNull(categories.Data);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        public async Task GetGamesBulkAsync_GetGamesInlineData(int pageSize)
        {
            var client = new SpeedrunComApiClient(_realLimitedRequester);
            var games = await client.Games.GetGamesBulkAsync(pageSize: pageSize);

            Assert.True(games.Data.Count == pageSize);
        }
    }
}
