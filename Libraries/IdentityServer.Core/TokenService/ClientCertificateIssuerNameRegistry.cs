/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System;
using System.IdentityModel.Tokens;

namespace IdentityServer.TokenService
{
    internal class ClientCertificateIssuerNameRegistry : IssuerNameRegistry
    {
        public override string GetIssuerName(SecurityToken securityToken)
        {
            if (securityToken == null)
            {
                Tracing.Error("ClientCertificateIssuerNameRegistry: securityToken is null");
                throw new ArgumentNullException("securityToken");
            }

            var token = securityToken as X509SecurityToken;
            if (token != null)
            {
                Tracing.Verbose("ClientCertificateIssuerNameRegistry: X509 SubjectName: " +
                                token.Certificate.SubjectName.Name);
                Tracing.Verbose("ClientCertificateIssuerNameRegistry: X509 Thumbprint : " + token.Certificate.Thumbprint);
                return token.Certificate.Thumbprint;
            }

            return null;
        }
    }
}