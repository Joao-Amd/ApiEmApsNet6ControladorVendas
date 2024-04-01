using ApiControladorVendas.Dominio.Identiys;
using ApiControladorVendas.Dominio.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControladorVendas.Repositorio.Configuracoes.Identity
{
    public class AspNetRoleConfig : IEntityTypeConfiguration<AspNetRole>
    {
        public void Configure(EntityTypeBuilder<AspNetRole> builder)
        {
            builder.ToTable("AspNetRoles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(x => x.NormalizedName)
                .HasColumnName("NormalizedName")
                .IsRequired();

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName("ConcurrencyStamp")
                .IsRequired();

        }
    }
}
