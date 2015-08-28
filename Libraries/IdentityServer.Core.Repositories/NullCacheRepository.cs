/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

namespace IdentityServer.Repositories
{
    public class NullCacheRepository : ICacheRepository
    {
        public void Put(string name, object value, int ttl)
        {
        }

        public object Get(string name)
        {
            return null;
        }

        public void Invalidate(string name)
        {
        }
    }
}