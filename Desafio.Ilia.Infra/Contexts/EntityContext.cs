using Desafio.Ilia.Domain.Entitities;
using Desafio.Ilia.Infra.Configs.Interfaces;
using Desafio.Ilia.Infra.Contexts.Base;
using Desafio.Ilia.Infra.Maps;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Ilia.Infra.Contexts
{
    public class EntityContext : EntityContextBase
    {
        // Usando o construtor para pegar a conexão com o banco através do método DBConfig().ConnectionString()
        private readonly IDbConfig _dbConfig;
        private DbContextOptions<EntityContext> options;

        public EntityContext(IDbConfig dbConfig) : base(dbConfig.ConnectionString())
        {
            _dbConfig = dbConfig;
        }

        public EntityContext(DbContextOptions<EntityContext> options, IDbConfig dbConfig) : base(dbConfig.ConnectionString())
        {
            this.options = options;
        }

        // Declaração das entidades
        public DbSet<Address> Address { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Phone> Phone { get; set; }

        // Configuração dos maps das tabelas no banco
        public override void Mapping(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new PhoneMap());
        }
    }
}
