using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentityServer.Protocols.OpenIdConnect
{
    public class OidcViewModel
    {
        private static readonly string[] SupportedScopes =
        {
            OidcConstants.Scopes.Profile,
            OidcConstants.Scopes.Phone,
            OidcConstants.Scopes.Address,
            OidcConstants.Scopes.Email
        };

        public OidcViewModel(ValidatedRequest validatedRequest)
        {
            if (validatedRequest == null) throw new ArgumentNullException("validatedRequest");
            ValidatedRequest = validatedRequest;
            ValidateScopes(GetRawScopes());
        }

        public ValidatedRequest ValidatedRequest { get; set; }

        public bool OfflineScope
        {
            get { return ValidatedRequest.Scopes.Contains(OidcConstants.Scopes.OfflineAccess); }
        }

        private void ValidateScopes(IEnumerable<string> scopes)
        {
            scopes = scopes ?? Enumerable.Empty<string>();

            var reminder = scopes
                .Except(SupportedScopes)
                .Except(new[]
                {
                    OidcConstants.Scopes.OpenId,
                    OidcConstants.Scopes.OfflineAccess
                });

            if (reminder.Any())
            {
                throw new Exception("Unsupported Scopes Requested");
            }
        }

        private IEnumerable<string> GetRawScopes()
        {
            return ValidatedRequest.Scopes.Split(
                new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        }

        private void SetRawScopes(IEnumerable<string> scopes)
        {
            ValidatedRequest.Scopes = scopes.Aggregate((x, y) => x + " " + y);
        }

        public IEnumerable<string> GetDisplayScopes()
        {
            var vals =
                GetRawScopes()
                    .Except(new[]
                    {
                        OidcConstants.Scopes.OpenId,
                        OidcConstants.Scopes.OfflineAccess
                    })
                    .Intersect(SupportedScopes);
            return vals;
        }

        public IEnumerable<string> GetScopes()
        {
            return GetRawScopes().Except(new[] {OidcConstants.Scopes.OpenId});
        }

        public void SetScopes(IEnumerable<string> scopes)
        {
            scopes = scopes ?? Enumerable.Empty<string>();
            ValidateScopes(scopes);

            var intersection = GetScopes().Intersect(scopes);
            var newScopes = new List<string>
            {
                OidcConstants.Scopes.OpenId
            };
            newScopes.AddRange(intersection);

            SetRawScopes(newScopes);
        }
    }
}