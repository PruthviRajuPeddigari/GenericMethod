using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CacheFunctionality
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectCache objCache = MemoryCache.Default;
            var policy = new CacheItemPolicy();
            var cacheId = AddIntoCache(objCache, policy);
            Console.WriteLine(GetValueFromCache(objCache, cacheId));
            var cacheeId = Guid.NewGuid().ToString();
            var output= objCache.AddOrGetExisting(cacheeId, 100, policy);
            Console.WriteLine(output);
            Console.WriteLine(GetValueFromCache(objCache, cacheeId));
            Console.ReadKey();
        }

        public static string AddIntoCache(ObjectCache cache,CacheItemPolicy policy)
        {
            var cacheId = Guid.NewGuid().ToString();
            cache.Add(cacheId, 10, policy);
            cache.Add(cacheId, 20, policy);
            return cacheId;
        }

        public static int GetValueFromCache(ObjectCache cache,string cacheId)
        {
            return (int)cache[cacheId];
        }

        public static void AddOrInsertIntoCache(ObjectCache cache, CacheItemPolicy policy,string cacheId)
        {
            
        }
    }
}
