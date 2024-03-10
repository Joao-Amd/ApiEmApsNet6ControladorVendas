using ApiControladorVendas.Dominio.Fornecedores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControladorVendas.Repositorio.Configuracoes.Fornecedores
{
    public class FornecedoresConfig : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("fornecedores");

            builder.HasKey(x  => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(x =>  x.Cnpj)
                .HasColumnName("cnpj")
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
