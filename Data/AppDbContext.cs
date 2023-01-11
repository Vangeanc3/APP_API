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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
            .HasOne(endereco => endereco.Usuario)
            .WithOne(usuario => usuario.Endereco)
            .HasForeignKey<Usuario>(usuario => usuario.EnderecoId);

            builder.Entity<Orcamento>()
            .HasOne(orcamento => orcamento.Instalador) // Instalador é o usuario
            .WithMany(instalador => instalador.Orcamentos)
            .HasForeignKey(orcamento => orcamento.InstaladorEmail);
            
            builder.Entity<Pedido>()
            .HasOne(pedido => pedido.Instalador) // Instalador é o usuario
            .WithMany(instalador => instalador.Pedidos)
            .HasForeignKey(pedido => pedido.InstaladorEmail);

            // builder.Entity<Produto>()
            // .HasOne(produto => produto.Orcamento)
            // .WithMany(orcamento => orcamento.Produtos)
            // .HasForeignKey<Orcamento>(orcamento => orcamento.)
        }

        public DbSet<Usuario> Usuarios { get; set; } = default!;
        public DbSet<Orcamento> Orcamentos { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; } = default!;
        public DbSet<Produto> Produtos { get; set; } = default!;

    }
}