/*
 * Copyright (c) Alexander Zhuang.  All rights reserved.
 * see license.txt
 */

using System.ComponentModel.Composition;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using IdentityServer.Models;
using IdentityServer.Protocols.OAuth2;
using IdentityServer.Repositories;
using Thinktecture.IdentityModel.Constants;

namespace IdentityServer.Protocols.OpenIdConnect
{
    public class OidcTokenController : ApiController
    {
        public OidcTokenController()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        [Import]
        public IStoredGrantRepository Grants { get; set; }

        [Import]
        public IOpenIdConnectClientsRepository Clients { get; set; }

        [Import]
        public IConfigurationRepository ServerConfiguration { get; set; }

        public HttpResponseMessage Post(TokenRequest request)
        {
            Tracing.Start("OIDC Token Endpoint");

            ValidatedRequest validatedRequest;

            try
            {
                var validator = new TokenRequestValidator(Clients, Grants);
                validatedRequest = validator.Validate(request, ClaimsPrincipal.Current);
            }
            catch (TokenRequestValidationException ex)
            {
                Tracing.Error("Aborting OIDC token request");
                return Request.CreateOAuthErrorResponse(ex.OAuthError);
            }

            // switch over the grant type
            if (validatedRequest.GrantType.Equals(OAuth2Constants.GrantTypes.AuthorizationCode))
            {
                return ProcessAuthorizationCodeRequest(validatedRequest);
            }
            if (string.Equals(validatedRequest.GrantType, OAuth2Constants.GrantTypes.RefreshToken))
            {
                return ProcessRefreshTokenRequest(validatedRequest);
            }

            Tracing.Error("unsupported grant type: " + request.Grant_Type);
            return Request.CreateOAuthErrorResponse(OAuth2Constants.Errors.UnsupportedGrantType);
        }

        private HttpResponseMessage ProcessRefreshTokenRequest(ValidatedRequest validatedRequest)
        {
            Tracing.Information("Processing refresh token request");

            var tokenService = new OidcTokenService(
                ServerConfiguration.Global.IssuerUri,
                ServerConfiguration.Keys.SigningCertificate);

            var response = tokenService.CreateTokenResponse(validatedRequest.Grant,
                validatedRequest.Client.AccessTokenLifetime);

            response.RefreshToken = validatedRequest.Grant.GrantId;
            return Request.CreateTokenResponse(response);
        }

        private HttpResponseMessage ProcessAuthorizationCodeRequest(ValidatedRequest validatedRequest)
        {
            Tracing.Information("Processing authorization code request");

            var tokenService = new OidcTokenService(
                ServerConfiguration.Global.IssuerUri,
                ServerConfiguration.Keys.SigningCertificate);

            var response = tokenService.CreateTokenResponse(validatedRequest.Grant,
                validatedRequest.Client.AccessTokenLifetime);
            Grants.Delete(validatedRequest.Grant.GrantId);

            if (validatedRequest.Grant.Scopes.Contains(OidcConstants.Scopes.OfflineAccess) &&
                validatedRequest.Client.AllowRefreshToken)
            {
                var refreshToken = StoredGrant.CreateRefreshToken(
                    validatedRequest.Grant.ClientId,
                    validatedRequest.Grant.Subject,
                    validatedRequest.Grant.Scopes,
                    validatedRequest.Client.RefreshTokenLifetime);

                Grants.Add(refreshToken);
                response.RefreshToken = refreshToken.GrantId;
            }

            return Request.CreateTokenResponse(response);
        }
    }
}