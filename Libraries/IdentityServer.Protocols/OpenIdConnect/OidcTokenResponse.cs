using Newtonsoft.Json;

namespace IdentityServer.Protocols.OpenIdConnect
{
    public class OidcTokenResponse : TokenResponse
    {
        [JsonProperty(PropertyName = "id_token")]
        public string IdentityToken { get; set; }
    }
}