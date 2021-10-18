using Moq;
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
    public class CategoriesApi
    {
        private Mock<IRateLimitedRequester> _rateLimitedRequester;
        private const string CategoryByIdResponsePath = "./Responses/CategoryById_Response.txt";

        public CategoriesApi()
        {
            _rateLimitedRequester = new Mock<IRateLimitedRequester>();
        }

        [Fact]
        public async Task GetCategoriesAsync_GetListOfCategories()
        {
            _rateLimitedRequester.Setup(moq => moq.CreateGetRequestAsync(It.IsAny<string>(), It.IsAny<List<string>>())).ReturnsAsync(File.ReadAllText(CategoryByIdResponsePath));

            var client = new SpeedrunComApiClient(_rateLimitedRequester.Object);
            var categories = await client.Categories.GetCategoryByIdAsync("nxd1rk8q");

            Assert.NotNull(categories);
        }
    }
}
