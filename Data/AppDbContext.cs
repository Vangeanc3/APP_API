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

            builder.Entity<Usuario>() // Definindo um atributo unico
                .HasIndex(usuario => usuario.Email).IsUnique();

            // Fazendo relações entre tabelas
            builder.Entity<Endereco>() // Usuario tem um Endereço
                .HasOne(endereco => endereco.Usuario)
                .WithMany(usuario => usuario.Enderecos)
                .HasForeignKey(endereco => endereco.UsuarioId);

            builder.Entity<Orcamento>() // Usuario tem uma lista de Orçamentos
            .HasOne(orcamento => orcamento.Instalador) // Instalador é o usuario
            .WithMany(instalador => instalador.Orcamentos)
            .HasForeignKey(orcamento => orcamento.InstaladorId);
            
            builder.Entity<Pedido>() // Usuario tem uma lista de pedidos
            .HasOne(pedido => pedido.Instalador) // Instalador é o usuario
            .WithMany(instalador => instalador.Pedidos)
            .HasForeignKey(pedido => pedido.InstaladorId);

            builder.Entity<Linha>() // Relação entre linha? e categoria
                .HasOne(linha => linha.Categoria)
                .WithMany(categoria => categoria.Linhas)
                .HasForeignKey(linha => linha.CategoriaId);

            builder.Entity<Produto>() // Produto tem obrigatoriamente uma categoria
                .HasOne(produto => produto.Categoria)
                .WithMany(categoria => categoria.Produtos)
                .HasForeignKey(produto => produto.CategoriaId);

            builder.Entity<Produto>() // Relação entre linha e produto - Produto tem uma linha
                .HasOne(produto => produto.Linha)
                .WithMany(linha => linha.Produtos)
                .HasForeignKey(produto => produto.LinhaId);

            builder.Entity<Produto>() // Relacao N para N => Produto está em vários orcamentos e vice versa
                .HasMany(produto => produto.Orcamentos)
                .WithMany(orcamentos => orcamentos.Produtos)
                .UsingEntity(juncao => juncao.ToTable("OrcamentoProdutos")); // No final vai virar essa tabela

            builder.Entity<Produto>() // Relacao N para N => Produto está em vários pedidos e vice versa
                .HasMany(produto => produto.Pedidos)
                .WithMany(pedidos => pedidos.Produtos)
                .UsingEntity(juncao => juncao.ToTable("PedidoProdutos")); // No final vai virar essa tabela

        }

        public DbSet<Usuario> Usuarios { get; set; } = default!;
        public DbSet<Endereco> Enderecos { get; set; } = default!;
        public DbSet<Orcamento> Orcamentos { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; } = default!;
        public DbSet<Categoria> Categorias { get; set; } = default!;
        public DbSet<Linha> Linhas { get; set; } = default!;
        public DbSet<Produto> Produtos { get; set; } = default!;

    }
}