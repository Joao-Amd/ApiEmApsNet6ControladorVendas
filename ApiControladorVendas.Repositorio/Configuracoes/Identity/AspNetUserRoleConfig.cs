using ApiControladorVendas.Dominio.Identiys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControladorVendas.Repositorio.Configuracoes.Identity
{
    public class AspNetUserRoleConfig : IEntityTypeConfiguration<AspNetUserRole>
    {
        public void Configure(EntityTypeBuilder<AspNetUserRole> builder)
        {
            builder.ToTable("AspNetUserRoles");

            builder.HasKey(x => new { x.UserId, x.RoleId });

            builder.Property(x => x.UserId)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(x => x.RoleId)
                .HasColumnName("email")
                .IsRequired();
        }
    }
}
