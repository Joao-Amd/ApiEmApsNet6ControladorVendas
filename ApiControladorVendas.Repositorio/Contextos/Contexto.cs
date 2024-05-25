using ApiControladorVendas.Dominio.AuthenticateService;
using ApiControladorVendas.Dominio.Clientes;
using ApiControladorVendas.Dominio.Fornecedores;
using ApiControladorVendas.Dominio.ItemVendas;
using ApiControladorVendas.Dominio.Itens;
using ApiControladorVendas.Dominio.Usuarios;
using ApiControladorVendas.Dominio.Vendas;
using ApiControladorVendas.Repositorio.Configuracoes.Clientes;
using ApiControladorVendas.Repositorio.Configuracoes.Fornecedores;
using ApiControladorVendas.Repositorio.Configuracoes.ItemVendas;
using ApiControladorVendas.Repositorio.Configuracoes.itens;
using ApiControladorVendas.Repositorio.Configuracoes.Usuarios;
using ApiControladorVendas.Repositorio.Configuracoes.Vendas;
using Microsoft.EntityFrameworkCore;

namespace ApiControladorVendas.Repositorio.Contextos
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options) { }
        
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Fornecedor> Fornecedores { get; set; }
        public virtual DbSet<Usuario> Funcionarios { get; set; }
        public virtual DbSet<ItemVenda> ItensVendas { get; set; }
        public virtual DbSet<Item> Produtos { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<RefreshToken> RefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new FornecedoresConfig());
            modelBuilder.ApplyConfiguration(new ItemVendaConfig());
            modelBuilder.ApplyConfiguration(new ItemConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new VendaConfig());
        }
    }
}
