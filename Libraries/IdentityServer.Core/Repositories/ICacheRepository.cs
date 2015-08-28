/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

namespace IdentityServer.Repositories
{
    public interface ICacheRepository
    {
        void Put(string name, object value, int ttl);
        object Get(string name);
        void Invalidate(string name);
    }
}