using Desafio.Ilia.Infra.Configs.Interfaces;

namespace Desafio.Ilia.Infra.Configs
{
    /// <summary>
    /// Classe responsável por informar o nome da connection string com o banco
    /// </summary>
    public class DBConfig : IDbConfig
    {
        public DBConfig()
        {

        }

        // Método responsável por armazenar o nome da connection string presente no appsettings.json
        public string ConnectionString()
        {
            return "connectionString";
        }
    }
}
