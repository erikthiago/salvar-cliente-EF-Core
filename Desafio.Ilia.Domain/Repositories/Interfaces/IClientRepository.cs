using Desafio.Ilia.Domain.Base.Interfaces;
using Desafio.Ilia.Domain.Entitities;
using Desafio.Ilia.Domain.Entitities.ConfigTree;
using System.Collections.Generic;

namespace Desafio.Ilia.Domain.Repositories.Interfaces
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        List<Client> GetEntities();
        TreeExtensions.ITree<Client> GetEntitiesTree();
        bool FindEmail(string email);
    }
}
