using ApiControladorVendas.Dominio.Usuarios;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ApiControladorVendas.Dominio.Identiys;

namespace ApiControladorVendas.Repositorio.Configuracoes.Identity
{
    public class AspNetUserClaimConfig : IEntityTypeConfiguration<AspNetUserClaim>
    {
        public void Configure(EntityTypeBuilder<AspNetUserClaim> builder)
        {
            builder.ToTable("AspNetUserClaims");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(x => x.ClaimType)
                .HasColumnName("ClaimType")
                .IsRequired();

            builder.Property(x => x.ClaimValue)
                .HasColumnName("ClaimValue")
                .IsRequired();

        }
    }
}
