using Moq;
using SpeedrunComApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SpeedrunComApi.Tests
{
    public class CategoriesApi
    {
        private Mock<IRateLimitedRequester> _rateLimitedRequester;

        public CategoriesApi()
        {
            _rateLimitedRequester = new Mock<IRateLimitedRequester>();
        }

        [Fact]
        public async Task GetCategoriesAsync_GetListOfCategories()
        {
            var client = new SpeedrunComApiClient(_rateLimitedRequester.Object);
            var categories = await client.Categories.GetCategoryByIdAsync("1");

            Assert.NotNull(categories);
        }
    }
}
