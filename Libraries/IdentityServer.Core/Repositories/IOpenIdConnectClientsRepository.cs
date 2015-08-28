using System.Collections.Generic;
using IdentityServer.Models;

namespace IdentityServer.Repositories
{
    public interface IOpenIdConnectClientsRepository
    {
        // needed for core issuance logic
        bool ValidateClient(string clientId, string clientSecret);
        bool ValidateClient(string clientId, string clientSecret, out OpenIdConnectClient client);
        // management 
        IEnumerable<OpenIdConnectClient> GetAll();
        OpenIdConnectClient Get(string clientId);
        void Delete(string clientId);
        void Update(OpenIdConnectClient model);
        void Create(OpenIdConnectClient model);
    }
}