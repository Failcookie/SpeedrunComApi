using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpeedrunComApi.Tests
{
    public class GamesApi
    {
        [Fact]
        public async Task GetGamesAsync_GetListOfGames()
        {
            var client = new SpeedrunComApiClient();
            var games = await client.Games.GetGamesAsync();

            Assert.NotNull(games.Data);
        }

        [Fact]
        public async Task GetGamesBulkAsync_GetDefault100Games()
        {
            var client = new SpeedrunComApiClient();
            var games = await client.Games.GetGamesBulkAsync();

            Assert.True(games.Data.Count == 100);
        }

        [Fact]
        public async Task GetGame_SuperMario64()
        {
            var client = new SpeedrunComApiClient();
            var game = await client.Games.GetGameAsync("o1y9wo6q");

            Assert.NotNull(game.Data);
        }

        [Fact]
        public async Task GetGameCategories_SuperMario64Categories()
        {
            var client = new SpeedrunComApiClient();
            var categories = await client.Games.GetGameGategoriesAsync("o1y9wo6q", false);

            Assert.NotNull(categories.Data);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        public async Task GetGamesBulkAsync_GetGamesInlineData(int pageSize)
        {
            var client = new SpeedrunComApiClient();
            var games = await client.Games.GetGamesBulkAsync(pageSize: pageSize);

            Assert.True(games.Data.Count == pageSize);
        }
    }
}
