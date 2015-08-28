/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System;
using System.Runtime.Caching;

namespace IdentityServer.Repositories
{
    public class MemoryCacheRepository : ICacheRepository
    {
        private static readonly MemoryCache _cache = new MemoryCache("IdentityServer.Caching");

        public void Put(string name, object value, int ttl)
        {
            Tracing.Verbose(string.Format("Adding {0} to cache", name));
            _cache.Add(name, value, DateTimeOffset.Now.AddHours(ttl));
        }

        public object Get(string name)
        {
            var item = _cache.Get(name);
            Tracing.Verbose(string.Format("Fetching {0} from cache: {1}", name, item == null ? "miss" : "hit"));

            return item;
        }

        public void Invalidate(string name)
        {
            Tracing.Verbose(string.Format("Invalidating {0} in cache", name));
            _cache.Remove(name);
        }
    }
}