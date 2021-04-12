using Desafio.Ilia.Domain.Entitities;
using Desafio.Ilia.Domain.Entitities.ConfigTree;
using Desafio.Ilia.Domain.Repositories.Interfaces;
using Desafio.Ilia.Infra.Contexts;
using Desafio.Ilia.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Ilia.Infra.Repositories
{
    public class ClientRepository : BaseRepository<Client, EntityContext>, IClientRepository
    {
        private readonly EntityContext _contextEntity;

        public ClientRepository(EntityContext contextEntity) : base(contextEntity)
        {
            _contextEntity = contextEntity;
        }

        /// <summary>
        /// Obtêm todos os clientes, independentemente de estarem relacionados
        /// </summary>
        /// <returns>A lista geral de clientes</returns>
        public List<Client> GetEntities()
        {
            return _contextEntity.Client.AsNoTracking()
                                        .AsQueryable()
                                        .Include(x => x.Addresses)
                                        .Include(x => x.Phones)
                                        .ToList();
        }

        /// <summary>
        /// Obtêm os clientes relacionados entre sí
        /// </summary>
        /// <returns>Retorna a lista de clientes e seus companheiros que vivem junto com todos os seus dados</returns>
        public TreeExtensions.ITree<Client> GetEntitiesTree()
        {
            var clients = _contextEntity.Client.AsNoTracking()
                                        .AsQueryable()
                                        .Include(x => x.Addresses)
                                        .Include(x => x.Phones)
                                        .ToList();

            TreeExtensions.ITree<Client> virtualRootNode = clients.ToTree((parent, child) => child.PrincipalId == parent.Id);

            return virtualRootNode;
        }

        /// <summary>
        /// Método usado para verificar se o email informado já existe no banco de dados
        /// </summary>
        /// <param name="email">O email a ser verificado</param>
        /// <returns>Retorna true para existente e false para não existente</returns>
        public bool FindEmail(string email)
        {
            var clientSelected = _contextEntity.Client.FirstOrDefault(x => x.Email == email);
            return clientSelected != null;
        }
    }
}
