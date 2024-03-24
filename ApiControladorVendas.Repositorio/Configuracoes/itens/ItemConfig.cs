using ApiControladorVendas.Dominio.Itens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControladorVendas.Repositorio.Configuracoes.itens
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("itens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("descricao")
                .IsRequired();

            builder.Property(x => x.Preco)
                .HasColumnName("preco")
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .HasColumnName("quantidade")
                .IsRequired();

            builder.Property(x => x.IdFornecedor)
                .HasColumnName("idfornecedor")
                .IsRequired();

            builder.HasOne(x => x.Fornecedor)
                .WithMany()
                .HasForeignKey(x => x.IdFornecedor);
        }
    }
}
