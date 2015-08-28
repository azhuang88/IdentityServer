/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System;
using System.ComponentModel.Composition;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using IdentityServer.Repositories;
using Thinktecture.IdentityModel.Authorization.WebApi;
using Thinktecture.IdentityModel.Constants;

namespace IdentityServer.Protocols.SimpleHTTP
{
    [ClaimsAuthorize(Constants.Actions.Issue, Constants.Resources.SimpleHttp)]
    public class SimpleHttpController : ApiController
    {
        public SimpleHttpController()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public SimpleHttpController(IConfigurationRepository configurationRepository)
        {
            ConfigurationRepository = configurationRepository;
        }

        [Import]
        public IConfigurationRepository ConfigurationRepository { get; set; }

        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            Tracing.Information("Simple HTTP endpoint called.");

            var query = request.GetQueryNameValuePairs();
            var auth = new AuthenticationHelper();

            var realm = query.FirstOrDefault(p => p.Key.Equals("realm", StringComparison.OrdinalIgnoreCase)).Value;
            var tokenType =
                query.FirstOrDefault(p => p.Key.Equals("tokenType", StringComparison.OrdinalIgnoreCase)).Value;

            if (string.IsNullOrWhiteSpace(realm))
            {
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "realm parameter is missing.");
            }

            EndpointReference appliesTo;
            try
            {
                appliesTo = new EndpointReference(realm);
                Tracing.Information("Simple HTTP endpoint called for realm: " + realm);
            }
            catch
            {
                Tracing.Error("Malformed realm: " + realm);
                return request.CreateErrorResponse(HttpStatusCode.BadRequest, "malformed realm name.");
            }

            if (string.IsNullOrWhiteSpace(tokenType))
            {
                tokenType = ConfigurationRepository.Global.DefaultHttpTokenType;
            }
            else
            {
                if (tokenType.Equals("jwt"))
                {
                    tokenType = TokenTypes.JsonWebToken;
                }
                else if (tokenType.Equals("swt"))
                {
                    tokenType = TokenTypes.SimpleWebToken;
                }
                else if (tokenType.Equals("saml11"))
                {
                    tokenType = TokenTypes.Saml11TokenProfile11;
                }
                else if (tokenType.Equals("saml2"))
                {
                    tokenType = TokenTypes.Saml2TokenProfile11;
                }
            }

            Tracing.Verbose("Token type: " + tokenType);

            TokenResponse tokenResponse;
            var sts = new STS();
            if (sts.TryIssueToken(appliesTo, ClaimsPrincipal.Current, tokenType, out tokenResponse))
            {
                var resp = request.CreateResponse(HttpStatusCode.OK, tokenResponse);
                return resp;
            }
            return request.CreateErrorResponse(HttpStatusCode.BadRequest, "invalid request.");
        }
    }
}