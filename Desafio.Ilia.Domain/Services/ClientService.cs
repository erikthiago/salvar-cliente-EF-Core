using Desafio.Ilia.Domain.Base.Interfaces;
using Desafio.Ilia.Domain.Entitities;
using Desafio.Ilia.Domain.Entitities.ConfigTree;
using Desafio.Ilia.Domain.Extensions;
using Desafio.Ilia.Domain.Repositories.Interfaces;
using Desafio.Ilia.Domain.Services.Interfaces;
using Flunt.Notifications;
using System;
using System.Collections.Generic;

namespace Desafio.Ilia.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUnitOfWork _uow;

        public ClientService(IClientRepository clientRepository, IUnitOfWork uow)
        {
            _clientRepository = clientRepository;
            _uow = uow;
        }

        /// <summary>
        /// Insere um novo cliente no banco de dados
        /// </summary>
        /// <param name="client">Os dados do cliente para serem salvos no banco</param>
        /// <returns>Retorna uma mensagem informando se deu certo ou não</returns>>
        public AddResponse<Client> AddClient(Client client)
        {
            if (Notifications(client).Count > 0)
                return new AddResponse<Client>(null, false, Notifications(client).Messages());

            // Verifica se o e-mail já existe no banco, se já existe, não deixa cadastrar o registro
            if (_clientRepository.FindEmail(client.Email))
                return new AddResponse<Client>(null, false, "O email informaodo já existe na base de dados!");

            _clientRepository.Add(client);

            return new AddResponse<Client>(client, _uow.Commit(), "Cliente cadastrado com sucesso");
        }

        /// <summary>
        /// Obtêm o cliente a partir do ID informado
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns>Retorna o cliente com o id informado com todos os seus dados</returns>
        public Client GetClient(Guid id)
        {
            return _clientRepository.GetById(id);
        }

        /// <summary>
        /// Obtêm todos os clientes, independentemente de estarem relacionados
        /// </summary>
        /// <returns>A lista geral de clientes</returns>
        public List<Client> GetClients()
        {
            return _clientRepository.GetEntities();
        }

        /// <summary>
        /// Obtêm os clientes relacionados entre sí
        /// </summary>
        /// <returns>Retorna a lista de clientes e seus companheiros que vivem junto com todos os seus dados</returns>
        public TreeExtensions.ITree<Client> GetEntitiesTree()
        {
            return _clientRepository.GetEntitiesTree();
        }

        /// <summary>
        /// Exclui os dados do cliente no banco de dados a partir do id informado
        /// </summary>
        /// <param name="id">Identificação do cliente a ser excluído do banco</param>
        /// <returns>Retorna uma mensagem informando se deu certo ou não</returns>
        public AddResponse<Client> RemoveClient(Guid id)
        {
            if (id == Guid.Empty)
                return new AddResponse<Client>(null, false, "Não foi possível excluir. Verifique os dados, por favor!");

            _clientRepository.Remove(id);

            return new AddResponse<Client>(null, _uow.Commit(), "Cliente excluído com sucesso");
        }

        /// <summary>
        /// Altera os dados do cliente no banco de dados
        /// </summary>
        /// <param name="value">Os dados do cliente para serem alterados no banco</param>
        /// <returns>Retorna uma mensagem informando se deu certo ou não</returns>
        public AddResponse<Client> UpdateClient(Client client)
        {
            if (Notifications(client).Count > 0)
                return new AddResponse<Client>(null, false, Notifications(client).Messages());

            // Verifica se o e-mail já existe no banco, se já existe, não deixa editar o registro
            if (_clientRepository.FindEmail(client.Email))
                return new AddResponse<Client>(null, false, "O email informaodo já existe na base de dados!");

            _clientRepository.Update(client);

            return new AddResponse<Client>(client, _uow.Commit(), "Cliente alterado com sucesso");
        }

        /// <summary>
        /// Método usado para centralizar todas as validações do cliente, endereço e telefone
        /// </summary>
        /// <param name="client">Objeto preenchido na tela com todos os dados</param>
        /// <returns>Retorna a lista de mensagens das validações</returns>
        private List<Notification> Notifications(Client client)
        {
            var notifications = new List<Notification>();

            var clientValidated = new Client(client.Name, client.Email);

            notifications.AddRange(clientValidated.Notifications);

            foreach (var item in client.Addresses)
            {
                var address = new Address(item.Street, item.Number, item.ZipCode, item.City, item.State, item.Country);

                if (!address.IsValid)
                    notifications.AddRange(address.Notifications);
            }

            foreach (var item in client.Phones)
            {
                var phones = new Phone(item.Number);

                if (!phones.IsValid)
                    notifications.AddRange(phones.Notifications);
            }

            return notifications;
        }
    }
}
