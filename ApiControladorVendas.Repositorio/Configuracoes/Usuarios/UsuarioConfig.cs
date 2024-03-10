using ApiControladorVendas.Dominio.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControladorVendas.Repositorio.Configuracoes.Usuarios
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasColumnName("senha")
                .IsRequired();

            builder.Property(x => x.NivelAcesso)
                .HasColumnName("nivelacesso")
                .IsRequired();
        }
    }
}
