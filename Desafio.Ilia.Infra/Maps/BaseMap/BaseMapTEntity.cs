using Desafio.Ilia.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Ilia.Infra.Maps.BaseMap
{
    public abstract class BaseMapTEntity<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        // Nome da tabela
        private readonly string _table;

        // Passa o nome da tabela via construtor para que possa configurar o nome da tabela no banco
        public BaseMapTEntity(string table)
        {
            _table = table;
        }

        // Configuração do que é comum
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            // Nome da tabela
            builder.ToTable(_table);

            // Configuração dos campos
            builder.Property(e => e.Id)
                .HasColumnName("Id");

            builder.Property(e => e.CreatedTime)
                .HasColumnName("DataHoraCriacao");

            builder.Property(e => e.UpdatedTime)
               .HasColumnName("DataHoraAlteracao");
        }
    }
}
