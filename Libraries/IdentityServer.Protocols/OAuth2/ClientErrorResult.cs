/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System;
using System.Net;
using System.Web.Mvc;
using Thinktecture.IdentityModel.Constants;

namespace IdentityServer.Protocols.OAuth2
{
    internal class ClientErrorResult : RedirectResult
    {
        public ClientErrorResult(Uri redirectUri, string error, string responseType, string state = null)
            : base(ConstructErrorUrl(redirectUri, error, responseType, state))
        {
        }

        private static string ConstructErrorUrl(Uri redirectUri, string error, string responseType, string state)
        {
            string url;
            var separator = "?";

            if (responseType == OAuth2Constants.ResponseTypes.Token)
            {
                separator = "#";
            }

            if (string.IsNullOrWhiteSpace(state))
            {
                url = string.Format("{0}{1}error={2}", redirectUri.AbsoluteUri, separator, error);
            }
            else
            {
                url = string.Format("{0}{1}error={2}&state={3}", redirectUri.AbsoluteUri, separator, error,
                    WebUtility.UrlEncode(state));
            }

            Tracing.Information("Sending back error response to client: " + url);
            return url;
        }
    }
}