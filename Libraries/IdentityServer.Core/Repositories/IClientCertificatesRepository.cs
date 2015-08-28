/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using IdentityServer.Models;

namespace IdentityServer.Repositories
{
    public interface IClientCertificatesRepository
    {
        // management
        bool SupportsWriteAccess { get; }
        // run time
        bool TryGetUserNameFromThumbprint(X509Certificate2 certificate, out string userName);
        IEnumerable<string> List(int pageIndex, int pageSize);
        IEnumerable<ClientCertificate> GetClientCertificatesForUser(string userName);
        void Add(ClientCertificate certificate);
        void Delete(ClientCertificate certificate);
    }
}