/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.Collections.Generic;
using IdentityServer.Models;

namespace IdentityServer.Repositories
{
    public interface IDelegationRepository
    {
        // management
        bool SupportsWriteAccess { get; }
        // run time
        bool IsDelegationAllowed(string userName, string realm);
        IEnumerable<string> GetAllUsers(int pageIndex, int pageSize);
        IEnumerable<DelegationSetting> GetDelegationSettingsForUser(string userName);
        void Add(DelegationSetting setting);
        void Delete(DelegationSetting setting);
    }
}