using ApiControladorVendas.Dominio.ItemVendas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControladorVendas.Repositorio.Configuracoes.ItemVendas
{
    public class ItemVendaConfig : IEntityTypeConfiguration<ItemVenda>
    {
        public void Configure(EntityTypeBuilder<ItemVenda> builder)
        {
            builder.ToTable("itensvendas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            //builder.Property(x => x.IdVenda)
            //    .HasColumnName("idvenda")
            //    .IsRequired();

            builder.Property(x => x.IdItem)
                .HasColumnName("idproduto")
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .HasColumnName("quantidade")
                .IsRequired();

            builder.Property(x => x.Subtotal)
                .HasColumnName("subtotal")
                .IsRequired();

            //builder.HasOne(x => x.Venda)
            //     .WithMany()
            //     .HasForeignKey(x => x.IdVenda);
        }
    }
}
