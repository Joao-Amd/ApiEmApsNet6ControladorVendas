using ApiControladorVendas.Dominio.Vendas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiControladorVendas.Repositorio.Configuracoes.Vendas
{
    public class VendaConfig : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("item");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .IsRequired();

            builder.Property(x => x.IdCliente)
                .HasColumnName("idcliente")
                .IsRequired();

            builder.Property(x => x.DataVenda)
                .HasColumnName("datavenda")
                .IsRequired();

            builder.Property(x => x.TotalVenda)
                .HasColumnName("totalvenda")
                .IsRequired();

            builder.Property(x => x.Observacoes)
                .HasColumnName("observacoes")
                .IsRequired();

            builder.HasOne(x => x.Cliente)
                .WithMany()
                .HasForeignKey(x => x.IdCliente);

        }
    }
}
