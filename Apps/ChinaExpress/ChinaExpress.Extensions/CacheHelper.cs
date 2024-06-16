using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChinaExpress.Extensions
{
    public class CacheHelper
    {
        private readonly IMemoryCache _cache;

        public CacheHelper(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public void SetValue(string key, object value, TimeSpan expiration)
        {
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(expiration);

            _cache.Set(key, value, cacheOptions);
        }

        public object GetValue(string key)
        {
            if (_cache.TryGetValue(key, out object value))
            {
                return value;
            }

            return null;
        }
    }
}
