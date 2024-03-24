
using ApiControladorVendas.Dominio.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControladorVendas.Repositorio.Configuracoes.Clientes
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .IsRequired();

            builder.Property(x => x.Nome)
                   .HasColumnName("nome")
                   .IsRequired();

            builder.Property(x => x.Cpf)
                   .HasColumnName("cpf")
                   .IsRequired();

            builder.Property(x => x.Email)
                   .HasColumnName("email")
                   .IsRequired();

            builder.Property(x => x.Celular)
                   .HasColumnName("celular")
                   .IsRequired();

            builder.Property(x => x.Cep)
                   .HasColumnName("cep")
                   .IsRequired();

            builder.Property(x => x.Endereco)
                   .HasColumnName("endereco")
                   .IsRequired();

            builder.Property(x => x.Numero)
                   .HasColumnName("numero")
                   .IsRequired();

            builder.Property(x => x.Complemento)
                   .HasColumnName("complemento")
                   .IsRequired();

            builder.Property(x => x.Bairro)
                   .HasColumnName("bairro")
                   .IsRequired();

            builder.Property(x => x.Cidade)
                   .HasColumnName("cidade")
                   .IsRequired();

            builder.Property(x => x.Estado)
                   .HasColumnName("estado")
                   .IsRequired();



        }
    }
}
