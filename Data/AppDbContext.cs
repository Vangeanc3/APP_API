using APP_API.Models;
using Microsoft.EntityFrameworkCore;

namespace APP_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts)
            : base(opts)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder) // Fazendo o mapeamento do banco de dados
        //{
        //    builder.Entity<>
        //}

        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Orcamento> Orcamentos { get; set; }
        //public DbSet<Instalador> Instaladores { get; set; }
        //public DbSet<Vendedor> Vendedores { get; set; }
        //public DbSet<Produto> Produtos { get; set; }
        //public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<Loja> Lojas { get; set; }
        //public DbSet<Pedido> Pedidos { get; set; }
        //public DbSet<Endereco> Enderecos { get; set; }

    }
}