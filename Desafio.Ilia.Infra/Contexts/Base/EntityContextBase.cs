using Desafio.Ilia.Infra.JsonClasses;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Desafio.Ilia.Infra.Contexts.Base
{
    public abstract class EntityContextBase : DbContext
    {
        // Nome da connection string
        private readonly string _connectionString;

        // Recebe o nome da connection string via construtor para poder acessar o banco
        public EntityContextBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Implementar o método de mapeamento das entidades no banco de dados
        /// </summary>
        /// <param name="modelBuilder">Objeto model builder para configurar os maps das entidades no banco</param>
        public abstract void Mapping(ModelBuilder modelBuilder);

        // Configurações para criar a tabela
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Mapping(modelBuilder);
            modelBuilder.Ignore<Notification>();
            base.OnModelCreating(modelBuilder);
        }

        // Configurar o acesso ao banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ReadJsonSettings readJsonSettings = new ReadJsonSettings(_connectionString);
            optionsBuilder.UseSqlServer(readJsonSettings.ConnectionString());
        }

        /// <summary>
        /// Método que realiza a inserção e edição de registros gravando a hora e o responsável pela operação
        /// </summary>
        /// <returns>A quantidade de linhas afetadas</returns>
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(x => x.Entity.GetType().GetProperty("CreatedTime") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedTime").CurrentValue = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    // Ignore the CreatedTime updates on Modified entities. 
                    entry.Property("CreatedTime").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries()
                                        .Where(e => e.Entity.GetType().GetProperty("UpdatedTime") != null &&
                                               e.State == EntityState.Modified || e.State == EntityState.Added))
            {
                entry.Property("UpdatedTime").CurrentValue = DateTime.Now;
                //entry.Property("CreatedBy").IsModified = false;
            }

            return base.SaveChanges();
        }
    }
}
