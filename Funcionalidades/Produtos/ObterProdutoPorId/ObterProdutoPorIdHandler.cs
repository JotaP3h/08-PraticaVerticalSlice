using Microsoft.EntityFrameworkCore;
using AprendizadoVerticalSlice.Infraestrutura;

namespace AprendizadoVerticalSlice.Funcionalidades.Produtos.ObterProdutoPorId;

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
/// Handler responsável por obter um produto específico por ID
/// </summary>
public class ObterProdutoPorIdHandler
{
    private readonly BancoDeDados _bancoDeDados;

    public ObterProdutoPorIdHandler(BancoDeDados bancoDeDados)
    {
        _bancoDeDados = bancoDeDados;
    }

    public async Task<ProdutoResposta?> Executar(int id)
    {
        // Busca o produto com sua categoria
        var produto = await _bancoDeDados.Produtos
            .Include(p => p.Categoria)
            .Where(p => p.Id == id)
            .Select(p => new ProdutoResposta(
                p.Id,
                p.Nome,
                p.Descricao,
                p.Preco,
                p.QuantidadeEstoque,
                p.CategoriaId,
                p.Categoria!.Nome
            ))
            .FirstOrDefaultAsync();

        return produto;
    }
}
