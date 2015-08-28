/*
 * Copyright (c) Alexander Zhuang, .  All rights reserved.
 * see license.txt
 */

using System.Collections.Generic;
using IdentityServer.Models;

namespace IdentityServer.Repositories
{
    /// <summary>
    ///     Repository for handling refresh tokens
    /// </summary>
    public interface ICodeTokenRepository
    {
        string AddCode(CodeTokenType type, int clientId, string userName, string scope);
        bool TryGetCode(string tokenIdentifier, out CodeToken token);
        void DeleteCode(string tokenIdentifier);
        IEnumerable<CodeToken> Search(int? clientId, string username, string scope, CodeTokenType type);
    }
}