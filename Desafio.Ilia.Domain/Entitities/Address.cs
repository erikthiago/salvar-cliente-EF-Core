using Desafio.Ilia.Domain.Base;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Desafio.Ilia.Domain.Entitities
{
    public class Address : BaseEntity
    {
        public Address()
        {

        }

        public Address(string street, int number, string zipCode, string city, string state, string country)
        {
            Street = street;
            Number = number;
            ZipCode = zipCode;
            City = city;
            State = state;
            Country = country;

            AddNotifications(new Contract<Notification>()
               .Requires()
               .IsNotNullOrEmpty(Street, "Rua", "O nome da rua deve ser informado")
               .IsGreaterOrEqualsThan(Number, 0, "Numero", "O número do endereço deve ser informado")
               .IsNotNullOrEmpty(ZipCode, "CEP", "O CEP deve ser informado")
               .IsNotNullOrEmpty(City, "Cidade", "O nome da cidade deve ser informado")
               .IsNotNullOrEmpty(State, "Estado", "O nome do estado deve ser informado")
               .IsNotNullOrEmpty(Country, "País", "O nome do país deve ser informado")
               );
        }

        /// <summary>
        /// Nome da rua
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Número da casa
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// CEP do endereço
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// Nome da cidade
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Nome do estado
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Nome do país
        /// </summary>
        public string Country { get; set; }

        //Relacionamentos 1 ciente pode ter N endereços

        /// <summary>
        /// Relacionamento com a tabela de cliente
        /// </summary>
        public Client Client { get; set; }
        /// <summary>
        /// Relacionamento com o cliente
        /// </summary>
        public Guid ClientId { get; set; }
    }
}