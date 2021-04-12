using Desafio.Ilia.Domain.Entitities;
using Desafio.Ilia.Infra.Maps.BaseMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Ilia.Infra.Maps
{
    public class ClientMap : BaseMapTEntity<Client>
    {
        public ClientMap() : base("CliCliente")
        {
        }

        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasColumnName("CliNome")
                   .HasColumnType("varchar(max)");

            builder.Property(d => d.Email)
                .IsRequired()
                .HasColumnName("CliEmail")
                .HasColumnType("varchar(max)");

            builder.HasOne(x => x.Principal)
                .WithMany(x => x.ClientsLiveTogether)
                .HasForeignKey(x => x.PrincipalId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
