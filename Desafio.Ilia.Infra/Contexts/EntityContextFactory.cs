using Desafio.Ilia.Infra.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Desafio.Ilia.Infra.Contexts
{
    public class EntityContextFactory : IDesignTimeDbContextFactory<EntityContext>
    {
        public EntityContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EntityContext>();
            var connectionString = configuration.GetConnectionString("connectionString");

            builder.UseSqlServer(connectionString);

            return new EntityContext(builder.Options, new DBConfig());
        }
    }
}
