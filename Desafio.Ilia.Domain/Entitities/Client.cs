using Desafio.Ilia.Domain.Base;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Desafio.Ilia.Domain.Entitities
{
    public class Client : BaseEntity
    {
        public Client()
        {

        }

        public Client(string name, string email)
        {
            Name = name;
            Email = email;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "O nome do cliente deve ser informado")
                .IsNotNullOrEmpty(Email, "Email", "O e-mail do cliente deve ser informado")
                .IsTrue(ValidateEmail(Email), "ValidarEmail", "")
                );
        }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Endereço de email
        /// </summary>
        public string Email { get; set; }

        // LINK DE REFERENCIA PARA FAZER A ROTINA DE AUTO REFERENCIA: 
        //https://medium.com/@dmitry.pavlov/tree-structure-in-ef-core-how-to-configure-a-self-referencing-table-and-use-it-53effad60bf

        // Relacionando se moram juntos

        /// <summary>
        /// Cliente pricipal
        /// </summary>
        public Client Principal { get; set; }
        /// <summary>
        /// Identificação do cliente principal
        /// </summary>
        public Guid? PrincipalId { get; set; }
        /// <summary>
        /// Para trazer os principal e os que vivem juntos com ele
        /// </summary>
        public ICollection<Client> ClientsLiveTogether { get; } = new List<Client>();

        // Relacionamento com as tabelas de endereço e telefone, pois o cliente pode conter mais de um endereço

        /// <summary>
        /// Lista de endereços que o cliente pode ter
        /// </summary>
        public IReadOnlyCollection<Address> Addresses { get; set; }

        /// <summary>
        /// Lista de telefones que o cliente pode ter
        /// </summary>
        public IReadOnlyCollection<Phone> Phones { get; set; }

        /// <summary>
        /// Método usado para validar o email informado
        /// </summary>
        /// <param name="emailaddress">Email a ser validado</param>
        /// <returns>Retorna true para válido e false para não inválido/returns>
        private bool ValidateEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                AddNotification("Email", "O email informado não é válido!");

                return false;
            }
        }
    }
}
