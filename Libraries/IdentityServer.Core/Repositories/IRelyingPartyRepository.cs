/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.Collections.Generic;
using IdentityServer.Models;

namespace IdentityServer.Repositories
{
    public interface IRelyingPartyRepository
    {
        // management
        bool SupportsWriteAccess { get; }
        bool TryGet(string realm, out RelyingParty relyingParty);
        IEnumerable<RelyingParty> List(int pageIndex, int pageSize);
        RelyingParty Get(string id);
        void Add(RelyingParty relyingParty);
        void Update(RelyingParty relyingParty);
        void Delete(string id);
    }
}