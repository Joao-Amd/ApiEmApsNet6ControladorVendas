using ApiControladorVendas.Dominio.Identiys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControladorVendas.Repositorio.Configuracoes.Identity
{
    public class AspNetUserConfig : IEntityTypeConfiguration<AspNetUser>
    {
        public void Configure(EntityTypeBuilder<AspNetUser> builder)
        {
            builder.ToTable("AspNetUsers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(x => x.UserName)
                .HasColumnName("UserName")
                .IsRequired();

            builder.Property(x => x.NormalizedUserName)
                .HasColumnName("NormalizedUserName")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .IsRequired();

            builder.Property(x => x.NormalizedEmail)
                .HasColumnName("NormalizedEmail")
                .IsRequired();

            builder.Property(x => x.EmailConfirmed)
                .HasColumnName("EmailConfirmed")
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .IsRequired();

            builder.Property(x => x.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .IsRequired();

            builder.Property(x => x.ConcurrencyStamp)
                .HasColumnName("ConcurrencyStamp")
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .IsRequired();

            builder.Property(x => x.PhoneNumberConfirmed)
                .HasColumnName("PhoneNumberConfirmed")
                .IsRequired();

            builder.Property(x => x.TwoFactorEnabled)
                .HasColumnName("TwoFactorEnabled")
                .IsRequired();

            builder.Property(x => x.LockoutEnd)
                .HasColumnName("LockoutEnd")
                .IsRequired();

            builder.Property(x => x.LockoutEnabled)
                .HasColumnName("LockoutEnabled")
                .IsRequired();

            builder.Property(x => x.AccessFailedCount)
                .HasColumnName("AccessFailedCount")
                .IsRequired();
        }
    }
}
