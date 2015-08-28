using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using IdentityServer.Models;
using IdentityServer.Repositories;
using System.Linq;
using System;

namespace ProgressIQ.IdentityServer.Web.Areas.Admin.ViewModels
{
    public class OpenIdConnectClientInputModel : IValidatableObject
    {
        public OpenIdConnectClient Client { get; set; }

        public void MapRedirectUris()
        {
            RedirectUris = null;
            if (Client.RedirectUris != null && Client.RedirectUris.Any())
            {
                RedirectUris = Client.RedirectUris.Aggregate((x, y) => x + Environment.NewLine + y);
            }
        }
        
        [DataType(DataType.MultilineText)]
        [Display(Name = @"Redirect Uris", Description = @"List of URIs allowed to redirect to in OAuth2 protocol.")]
        public string RedirectUris { get; set; }
        
        public string[] ParsedRedirectUris
        {
            get
            {
                if (RedirectUris == null)
                {
                    return new string[0];
                }
                else
                {
                    return RedirectUris.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
        }

        public System.Collections.Generic.IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var item in ParsedRedirectUris)
            {
                Uri val;
                if (!Uri.TryCreate(item, UriKind.Absolute, out val))
                {
                    yield return new ValidationResult(item + " is not a valid URI", new[] { "RedirectUris" });
                }
            }
        }
    }

    public class OpenIdConnectClientViewModel : OpenIdConnectClientInputModel
    {
        [Import]
        public IConfigurationRepository ConfigurationRepository { get; set; }

        public OpenIdConnectClientViewModel(OpenIdConnectClient client)
        {
            Container.Current.SatisfyImportsOnce(this);
            Client = client;
            MapRedirectUris();
        }

        public bool IsNew => string.IsNullOrWhiteSpace(Client.ClientId);

        public bool IsOAuthRefreshTokenEnabled => !IsNew && Client.Flow == OpenIdConnectFlows.AuthorizationCode;
    }
}