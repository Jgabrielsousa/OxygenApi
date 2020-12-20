using Oxygen.Data.Context;
using Oxygen.Data.Repository.Base;
using Oxygen.Domain.Entities;
using Oxygen.Domain.Interfaces.IRepository;

namespace Oxygen.Data.Repository
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(OxygenDbContext context): base(context)
        {
        }
    }
}
