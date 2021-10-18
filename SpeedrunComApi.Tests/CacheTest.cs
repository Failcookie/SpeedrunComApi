using SpeedrunComApi.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SpeedrunComApi.Tests
{

    public class CacheTest
    {
        [Fact]
        public void AddGet_TimeSpan_ShouldAddToTheCache_ReturnTrue()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 5, 0));

            Assert.Equal(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [Fact]
        public void AddGet_TimeSpan_ShouldAddAndExpire_ReturnTrue()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.Equal(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            Thread.Sleep(2000);
            Assert.Null(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [Fact]
        public void AddGet_DateTime_ShouldAdd_ReturnTheTestValue()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, DateTime.Now + new TimeSpan(0, 5, 0));

            Assert.Equal(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [Fact]
        public void AddGet_DateTime_ShouldAddAndExpire_ReturnTrue()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, DateTime.Now + new TimeSpan(0, 0, 1));

            Assert.Equal(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            Thread.Sleep(2000);
            Assert.Null(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [Fact]
        public void Add_ShouldUpdateIfPresent_ReturnUpdatedValue()
        {
            Cache cache = new Cache();
            var otherValue = "otherValue";
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.Equal(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            cache.Add(CacheTestBase.TestKey, otherValue, new TimeSpan(0, 0, 1));
            Assert.Equal(otherValue, cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [Fact]
        public void Remove_ShouldDoNothingIfNull_ReturnDontThrowExceptionIfNull()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.Equal(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            cache.Remove<string>(null);
            Assert.Equal(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [Fact]
        public void Remove_ShouldDoNothingIfAbsent_ReturnNull()
        {
            Cache cache = new Cache();
            cache.Remove(CacheTestBase.TestKey);

            cache.Get<string, string>(CacheTestBase.TestKey);
            Assert.Null(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [Fact]
        public void Remove_ShouldRemoveIfPresent_ReturnNull()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.Equal(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            cache.Remove(CacheTestBase.TestKey);
            Assert.Null(cache.Get<string, string>(CacheTestBase.TestKey));
        }

        [Fact]
        public void Clear_ShouldRemoveAll_ReturnNull()
        {
            Cache cache = new Cache();
            cache.Add(CacheTestBase.TestKey, CacheTestBase.TestValue, new TimeSpan(0, 0, 1));

            Assert.Equal(CacheTestBase.TestValue, cache.Get<string, string>(CacheTestBase.TestKey));
            cache.Clear();
            Assert.Null(cache.Get<string, string>(CacheTestBase.TestKey));
        }
    }
}
