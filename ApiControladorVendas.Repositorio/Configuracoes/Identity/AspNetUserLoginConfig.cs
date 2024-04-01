using ApiControladorVendas.Dominio.Identiys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControladorVendas.Repositorio.Configuracoes.Identity
{
    public class AspNetUserLoginConfig : IEntityTypeConfiguration<AspNetUserLogin>
    {
        public void Configure(EntityTypeBuilder<AspNetUserLogin> builder)
        {
            builder.ToTable("AspNetUserLogins");

            builder.HasKey(x => new { x.LoginProvider, x.ProviderKey });

            builder.Property(x => x.LoginProvider)
                .HasColumnName("LoginProvider")
                .IsRequired();

            builder.Property(x => x.ProviderKey)
                .HasColumnName("ProviderKey")
                .IsRequired();

            builder.Property(x => x.ProviderDisplayName)
                .HasColumnName("ProviderDisplayName")
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("UserId")
                .IsRequired();
        }
    }
}
