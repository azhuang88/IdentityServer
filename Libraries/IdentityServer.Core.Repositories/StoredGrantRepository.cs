using System;
using System.Linq;

namespace IdentityServer.Repositories.Sql
{
    public class StoredGrantRepository : IStoredGrantRepository
    {
        public void Add(Models.StoredGrant grant)
        {
            var entity = grant.ToEntityModel();

            using (var entities = IdentityServerConfigurationContext.Get())
            {
                entities.StoredGrants.Add(entity);
                entities.SaveChanges();
            }
        }

        public Models.StoredGrant Get(string id)
        {
            using (var entities = IdentityServerConfigurationContext.Get())
            {
                var result = (from sg in entities.StoredGrants
                    where sg.GrantId == id
                    select sg)
                    .SingleOrDefault();

                if (result != null)
                {
                    return result.ToDomainModel();
                }

                return null;
            }
        }

        public void Delete(string id)
        {
            using (var entities = IdentityServerConfigurationContext.Get())
            {
                var item =
                    entities.StoredGrants.FirstOrDefault(x => x.GrantId.Equals(id, StringComparison.OrdinalIgnoreCase));
                if (item != null)
                {
                    entities.StoredGrants.Remove(item);
                    entities.SaveChanges();
                }
            }
        }
    }
}