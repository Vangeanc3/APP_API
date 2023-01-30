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

            // Definindo um atributos unico
            builder.Entity<Usuario>()
                .HasIndex(usuario => usuario.Email).IsUnique();

            builder.Entity<Orcamento>()
            .HasIndex(orcamento => orcamento.IdentificadorUnico).IsUnique();
            // FIM DOS ATRIBUTOS UNICOS 

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

            builder.Entity<Linha>() // Relação entre linha e categoria
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


            // RELAÇÕES N PARA N
            builder.Entity<DetalhePedido>()
                .HasKey(dp => new { dp.PedidoId, dp.ProdutoId });

            builder.Entity<DetalhePedido>()
                .HasOne(dp => dp.Pedido)
                .WithMany(pedido => pedido.DetalhePedidos)
                .HasForeignKey(dp => dp.PedidoId);

            builder.Entity<DetalhePedido>()
                .HasOne(dp => dp.Produto)
                .WithMany(produto => produto.DetalhePedidos)
                .HasForeignKey(dp => dp.ProdutoId);
            ////////////////////////////////////////
            builder.Entity<DetalheOrcamento>()
            .HasKey(op => new { op.ProdutoId, op.OrcamentoId });

            builder.Entity<DetalheOrcamento>()
            .HasOne(op => op.Orcamento)
            .WithMany(orcamento => orcamento.DetalhesOrcamentos)
            .HasForeignKey(op => op.OrcamentoId);

            builder.Entity<DetalheOrcamento>()
            .HasOne(op => op.Produto)
            .WithMany(produto => produto.DetalheOrcamentos)
            .HasForeignKey(op => op.ProdutoId);
            // FIM RELAÇÕES N PARA N
        }

        public DbSet<Usuario> Usuarios { get; set; } = default!;
        public DbSet<Endereco> Enderecos { get; set; } = default!;
        public DbSet<Orcamento> Orcamentos { get; set; } = default!;
        public DbSet<Pedido> Pedidos { get; set; } = default!;
        public DbSet<Categoria> Categorias { get; set; } = default!;
        public DbSet<Linha> Linhas { get; set; } = default!;
        public DbSet<Produto> Produtos { get; set; } = default!;
        public DbSet<DetalheOrcamento> DetalheOrcamento { get; set; }
        public DbSet<DetalhePedido> DetalhePedidos { get; set; }

    }
}