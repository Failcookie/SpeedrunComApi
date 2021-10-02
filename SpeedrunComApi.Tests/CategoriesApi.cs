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
        [Fact]
        public async Task GetCategoriesAsync_GetListOfCategories()
        {
            var client = new SpeedrunComApiClient();
            var categories = await client.Categories.GetCategoryByIdAsync("1");

            Assert.NotNull(categories);
        }
    }
}
