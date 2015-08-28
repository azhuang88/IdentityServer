/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System;

namespace IdentityServer.Protocols.OAuth2
{
    [Serializable]
    public class AuthorizeRequestClientException : AuthorizeRequestValidationException
    {
        public AuthorizeRequestClientException(string message, Uri redirectUri, string error, string responseType,
            string state = null)
            : base(message)
        {
            RedirectUri = redirectUri;
            Error = error;
            ResponseType = responseType;
            State = state;
        }

        public Uri RedirectUri { get; set; }
        public string Error { get; set; }
        public string ResponseType { get; set; }
        public string State { get; set; }
    }
}