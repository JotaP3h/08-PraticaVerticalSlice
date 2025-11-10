using Microsoft.EntityFrameworkCore;
using AprendizadoVerticalSlice.Funcionalidades.Produtos;
using AprendizadoVerticalSlice.Funcionalidades.Categorias;

namespace AprendizadoVerticalSlice.Infraestrutura;

/// <summary>
/// Contexto do banco de dados da aplicação
/// </summary>
public class BancoDeDados : DbContext
{
    public BancoDeDados(DbContextOptions<BancoDeDados> opcoes) : base(opcoes)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder construtorModelo)
    {
        base.OnModelCreating(construtorModelo);

        // Configuração da tabela Categorias
        construtorModelo.Entity<Categoria>(entidade =>
        {
            entidade.HasKey(c => c.Id);
            entidade.Property(c => c.Nome).IsRequired().HasMaxLength(100);
            entidade.Property(c => c.Descricao).HasMaxLength(500);
        });

        // Configuração da tabela Produtos
        construtorModelo.Entity<Produto>(entidade =>
        {
            entidade.HasKey(p => p.Id);
            entidade.Property(p => p.Nome).IsRequired().HasMaxLength(200);
            entidade.Property(p => p.Descricao).HasMaxLength(1000);
            entidade.Property(p => p.Preco).HasPrecision(18, 2);
            entidade.Property(p => p.QuantidadeEstoque).IsRequired();
            
            // Relacionamento Produto -> Categoria
            entidade.HasOne(p => p.Categoria)
                   .WithMany()
                   .HasForeignKey(p => p.CategoriaId)
                   .OnDelete(DeleteBehavior.Restrict);
        });

        // Dados iniciais para testes
        construtorModelo.Entity<Categoria>().HasData(
            new Categoria { Id = 1, Nome = "Eletrônicos", Descricao = "Produtos eletrônicos e tecnologia" },
            new Categoria { Id = 2, Nome = "Livros", Descricao = "Livros e publicações" },
            new Categoria { Id = 3, Nome = "Roupas", Descricao = "Vestuário e acessórios" }
        );

        construtorModelo.Entity<Produto>().HasData(
            new Produto 
            { 
                Id = 1, 
                Nome = "Notebook Dell", 
                Descricao = "Notebook Dell Inspiron 15", 
                Preco = 3500.00m,
                QuantidadeEstoque = 10,
                CategoriaId = 1
            },
            new Produto 
            { 
                Id = 2, 
                Nome = "Clean Code", 
                Descricao = "Livro sobre código limpo por Robert Martin", 
                Preco = 89.90m,
                QuantidadeEstoque = 25,
                CategoriaId = 2
            }
        );
    }
}
