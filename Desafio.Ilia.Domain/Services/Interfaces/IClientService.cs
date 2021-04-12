using Desafio.Ilia.Domain.Entitities;
using Desafio.Ilia.Domain.Entitities.ConfigTree;
using System;
using System.Collections.Generic;

namespace Desafio.Ilia.Domain.Services.Interfaces
{
    public interface IClientService
    {
        AddResponse<Client> AddClient(Client client);
        AddResponse<Client> UpdateClient(Client client);
        AddResponse<Client> RemoveClient(Guid id);
        List<Client> GetClients();
        TreeExtensions.ITree<Client> GetEntitiesTree();
        Client GetClient(Guid id);
    }
}
