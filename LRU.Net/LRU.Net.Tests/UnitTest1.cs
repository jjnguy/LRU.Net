using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LRU.Net.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static LruCache<string, string> GetInitializedCache(int max, params string[] entries)
        {
            var cache = new LruCache<string, string>(max);
            foreach (var entry in entries)
            {
                cache.Add(entry, entry);
            }
            return cache;
        }

        [TestMethod]
        public void TestMethod1()
        {
            var cache = GetInitializedCache(3, "one", "two", "tee", "for");

            Assert.IsNull(cache.Get("one"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var cache = GetInitializedCache(3, "one", "two", "tee");
            var one = cache.Get("one");
            cache.Add("for", "for");
            Assert.IsNull(cache.Get("two"));
        }
    }
}
