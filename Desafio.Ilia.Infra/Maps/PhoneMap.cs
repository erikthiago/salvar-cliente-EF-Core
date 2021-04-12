using Desafio.Ilia.Domain.Entitities;
using Desafio.Ilia.Infra.Maps.BaseMap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Ilia.Infra.Maps
{
    public class PhoneMap : BaseMapTEntity<Phone>
    {
        public PhoneMap() : base("TelTelefone")
        {
        }

        public override void Configure(EntityTypeBuilder<Phone> builder)
        {
            base.Configure(builder);

            builder.Property(d => d.PhoneType)
                   .IsRequired()
                   .HasColumnName("TelTipoTelefone")
                   .HasColumnType("int");

            builder.Property(d => d.Number)
                   .IsRequired()
                   .HasColumnName("TelNumero")
                   .HasColumnType("varchar(10)");

            builder.HasOne(ha => ha.Client)
                   .WithMany(p => p.Phones);
        }
    }
}
