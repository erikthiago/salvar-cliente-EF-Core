using Desafio.Ilia.Domain.Entitities;
using Desafio.Ilia.Domain.Entitities.ConfigTree;
using Desafio.Ilia.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Desafio.Ilia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Obtêm todos os clientes, independentemente de estarem relacionados
        /// </summary>
        /// <returns>A lista geral de clientes</returns>
        // GET: api/<ClientController>
        [HttpGet]
        public List<Client> Get()
        {
            return _clientService.GetClients();
        }

        /// <summary>
        /// Obtêm os clientes relacionados entre sí
        /// </summary>
        /// <returns>Retorna a lista de clientes e seus companheiros que vivem junto com todos os seus dados</returns>
        // GET: api/<ClientController>/tree
        [HttpGet("parents-children")]
        public TreeExtensions.ITree<Client> GetTree()
        {
            return _clientService.GetEntitiesTree();
        }

        /// <summary>
        /// Obtêm o cliente a partir do ID informado
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns>Retorna o cliente com o id informado com todos os seus dados</returns>
        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public Client Get(Guid id)
        {
            return _clientService.GetClient(id);
        }

        /// <summary>
        /// Insere um novo cliente no banco de dados
        /// </summary>
        /// <param name="value">Os dados do cliente para serem salvos no banco</param>
        /// <returns>Retorna uma mensagem informando se deu certo ou não</returns>
        // POST api/<ClientController>
        [HttpPost]
        public AddResponse<Client> Post([FromBody] Client value)
        {
            return _clientService.AddClient(value);
        }

        /// <summary>
        /// Altera os dados do cliente no banco de dados
        /// </summary>
        /// <param name="value">Os dados do cliente para serem alterados no banco</param>
        /// <returns>Retorna uma mensagem informando se deu certo ou não</returns>
        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public AddResponse<Client> Put([FromBody] Client value)
        {
            return _clientService.UpdateClient(value);
        }

        /// <summary>
        /// Exclui os dados do cliente no banco de dados a partir do id informado
        /// </summary>
        /// <param name="id">Identificação do cliente a ser excluído do banco</param>
        /// <returns>Retorna uma mensagem informando se deu certo ou não</returns>
        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public AddResponse<Client> Delete(Guid id)
        {
            return _clientService.RemoveClient(id);
        }
    }
}
