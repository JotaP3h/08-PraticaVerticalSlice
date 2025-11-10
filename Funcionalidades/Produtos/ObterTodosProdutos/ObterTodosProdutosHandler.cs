using Microsoft.EntityFrameworkCore;
using AprendizadoVerticalSlice.Infraestrutura;

namespace AprendizadoVerticalSlice.Funcionalidades.Produtos.ObterTodosProdutos;

/// <summary>
/// Resposta contendo os dados de um produto
/// </summary>
public record ProdutoResposta(
    int Id,
    string Nome,
    string? Descricao,
    decimal Preco,
    int QuantidadeEstoque,
    int CategoriaId,
    string NomeCategoria
);

/// <summary>
/// Handler responsável por obter todos os produtos
/// Cada funcionalidade tem sua própria classe de handler
/// </summary>
public class ObterTodosProdutosHandler
{
    private readonly BancoDeDados _bancoDeDados;

    public ObterTodosProdutosHandler(BancoDeDados bancoDeDados)
    {
        _bancoDeDados = bancoDeDados;
    }

    public async Task<List<ProdutoResposta>> Executar()
    {
        // Busca todos os produtos com suas categorias
        var produtos = await _bancoDeDados.Produtos
            .Include(p => p.Categoria)
            .Select(p => new ProdutoResposta(
                p.Id,
                p.Nome,
                p.Descricao,
                p.Preco,
                p.QuantidadeEstoque,
                p.CategoriaId,
                p.Categoria!.Nome
            ))
            .ToListAsync();

        return produtos;
    }
}
