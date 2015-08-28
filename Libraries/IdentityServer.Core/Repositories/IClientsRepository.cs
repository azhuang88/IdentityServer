using System.Collections.Generic;
using IdentityServer.Models;

namespace IdentityServer.Repositories
{
    public interface IClientsRepository
    {
        // needed for core issuance logic
        bool ValidateClient(string clientId, string clientSecret);
        bool TryGetClient(string clientId, out Client client);
        bool ValidateAndGetClient(string clientId, string clientSecret, out Client client);
        // management 
        IEnumerable<Client> GetAll();
        Client Get(int id);
        void Delete(int id);
        void Update(Client model);
        void Create(Client model);
    }
}