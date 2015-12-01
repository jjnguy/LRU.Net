using System;
using System.Linq;
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
            ExceptionAssert.Throws(()=> cache.Get("one"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var cache = GetInitializedCache(3, "one", "two", "tee");
            var one = cache.Get("one");
            cache.Add("for", "for");
            ExceptionAssert.Throws(()=> cache.Get("two"));
        }

        [TestMethod]
        public void StressTestMethod()
        {
            var numberOfEntires = 100000;
            var entries = Enumerable.Range(0, numberOfEntires).Select(i => i.ToString()).ToArray();
            var cache = GetInitializedCache(numberOfEntires / 10, entries);
            
            Assert.IsFalse(cache.Contains("1"));
        }
    }

    public static class ExceptionAssert
    {
        public static void Throws(Action code)
        {
            try
            {
                code();
                Assert.Fail("Should have thrown an exception");
            }
            catch (Exception e)
            {
                // yay!
            }
        }
    }
}
