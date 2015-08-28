/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.Composition;
using IdentityServer.Repositories;
using Thinktecture.IdentityModel.Tokens;

namespace IdentityServer.TokenService
{
    public class RepositoryUserNameSecurityTokenHandler : GenericUserNameSecurityTokenHandler
    {
        [Import]
        public IUserRepository UserRepository { get; set; }

        protected override bool ValidateUserNameCredentialCore(string userName, string password)
        {
            Container.Current.SatisfyImportsOnce(this);
            return UserRepository.ValidateUser(userName, password);
        }
    }
}