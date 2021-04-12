using Desafio.Ilia.Domain.Entitities;
using Desafio.Ilia.Infra.Maps.BaseMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Ilia.Infra.Maps
{
    public class AddressMap : BaseMapTEntity<Address>
    {
        public AddressMap() : base("EndEndereco")
        {
        }

        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Street)
                   .IsRequired()
                   .HasColumnName("EndRua")
                   .HasColumnType("varchar(max)");

            builder.Property(d => d.Number)
                   .IsRequired()
                   .HasColumnName("EndNumero")
                   .HasColumnType("int");

            builder.Property(d => d.ZipCode)
                   .IsRequired()
                   .HasColumnName("EndCEP")
                   .HasColumnType("varchar(10)");

            builder.Property(d => d.City)
                   .IsRequired()
                   .HasColumnName("EndCidade")
                   .HasColumnType("varchar(max)");

            builder.Property(d => d.State)
                   .IsRequired()
                   .HasColumnName("EndEstado")
                   .HasColumnType("varchar(max)");

            builder.Property(d => d.Country)
                   .IsRequired()
                   .HasColumnName("EndPais")
                   .HasColumnType("varchar(max)");

            builder.HasOne(ha => ha.Client)
                   .WithMany(p => p.Addresses);
        }
    }
}
