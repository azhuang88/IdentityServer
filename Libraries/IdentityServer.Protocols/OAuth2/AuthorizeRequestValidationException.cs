/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System;

namespace IdentityServer.Protocols.OAuth2
{
    [Serializable]
    public class AuthorizeRequestValidationException : Exception
    {
        public AuthorizeRequestValidationException(string message) : base(message)
        {
        }
    }
}