using Desafio.Ilia.Domain.Base;
using Desafio.Ilia.Domain.Enums;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace Desafio.Ilia.Domain.Entitities
{
    public class Phone : BaseEntity
    {
        public Phone()
        {

        }

        public Phone(string number)
        {
            Number = number;

            AddNotifications(new Contract<Notification>()
               .Requires()
               .IsNotNullOrEmpty(Number, "Numero", "O número de telefone do cliente deve ser informado")
               );
        }

        /// <summary>
        /// Número do telefone
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Tipo de telefone
        /// 1 = Fixo
        /// 2 = Movel
        /// </summary>
        public EPhoneType PhoneType { get; set; }

        //Relacionamentos 1 ciente pode ter N telefones

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