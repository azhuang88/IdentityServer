using IdentityServer.Models;

namespace IdentityServer.Repositories
{
    public interface IStoredGrantRepository
    {
        void Add(StoredGrant grant);
        StoredGrant Get(string id);
        void Delete(string id);
    }
}