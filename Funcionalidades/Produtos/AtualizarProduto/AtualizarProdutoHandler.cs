using AprendizadoVerticalSlice.Infraestrutura;
using Microsoft.EntityFrameworkCore;

namespace AprendizadoVerticalSlice.Funcionalidades.Produtos.AtualizarProduto;

/// <summary>
/// Requisição para atualizar um produto existente
/// </summary>
public record AtualizarProdutoRequisicao(
    string Nome,
    string? Descricao,
    decimal Preco,
    int QuantidadeEstoque,
    int CategoriaId
);

/// <summary>
/// Handler responsável por atualizar um produto
/// </summary>
public class AtualizarProdutoHandler
{
    private readonly BancoDeDados _bancoDeDados;

    public AtualizarProdutoHandler(BancoDeDados bancoDeDados)
    {
        _bancoDeDados = bancoDeDados;
    }

    public async Task<(bool Sucesso, string? Erro)> Executar(int id, AtualizarProdutoRequisicao requisicao)
    {
        // Validações básicas
        if (string.IsNullOrWhiteSpace(requisicao.Nome))
        {
            return (false, "O nome do produto é obrigatório.");
        }

        if (requisicao.Preco <= 0)
        {
            return (false, "O preço deve ser maior que zero.");
        }

        if (requisicao.QuantidadeEstoque < 0)
        {
            return (false, "A quantidade em estoque não pode ser negativa.");
        }

        // Busca o produto
        var produto = await _bancoDeDados.Produtos.FindAsync(id);
        
        if (produto == null)
        {
            return (false, $"Produto com ID {id} não encontrado.");
        }

        // Verifica se a categoria existe
        var categoriaExiste = await _bancoDeDados.Categorias
            .AnyAsync(c => c.Id == requisicao.CategoriaId);

        if (!categoriaExiste)
        {
            return (false, $"Categoria com ID {requisicao.CategoriaId} não encontrada.");
        }

        // Atualiza os dados do produto
        produto.Nome = requisicao.Nome;
        produto.Descricao = requisicao.Descricao;
        produto.Preco = requisicao.Preco;
        produto.QuantidadeEstoque = requisicao.QuantidadeEstoque;
        produto.CategoriaId = requisicao.CategoriaId;

        await _bancoDeDados.SaveChangesAsync();

        return (true, null);
    }
}
