using Flunt.Notifications;
using System;

namespace Desafio.Ilia.Domain.Base
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        /// <summary>
        /// Identificação
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Data de criação
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// Data de alteração
        /// </summary>
        public DateTime UpdatedTime { get; set; }
    }
}
