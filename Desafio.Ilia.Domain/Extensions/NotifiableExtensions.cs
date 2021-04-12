using Flunt.Notifications;
using System.Collections.Generic;

namespace Desafio.Ilia.Domain.Extensions
{
    /// <summary>
    /// Classe de extensão que junta todas as mensagens retornadas na validação de dados das classes
    /// </summary>
    public static class NotifiableExtensions
    {
        /// <summary>
        /// Método que reune todas as mensagens retornadas em uma variável e retorna elas uma abaixo da outra
        /// </summary>
        /// <param name="notifications">Objeto que contem herança com Notification</param>
        /// <returns>Retorna as mensagens uma abaixo da outra</returns>
        public static string Messages(this IReadOnlyCollection<Notification> notifications)
        {
            List<string> message = new List<string>();

            foreach (var item in notifications)
            {
                message.Add($"{item.Message} \n");
            }

            return string.Join("\r\n ", message);
        }
    }
}
