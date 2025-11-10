using AprendizadoVerticalSlice.Infraestrutura;
using Microsoft.EntityFrameworkCore;

namespace AprendizadoVerticalSlice.Funcionalidades.Produtos.CriarProduto;

/// <summary>
/// Requisição para criar um novo produto
/// </summary>
public record CriarProdutoRequisicao(
    string Nome,
    string? Descricao,
    decimal Preco,
    int QuantidadeEstoque,
    int CategoriaId
);

/// <summary>
/// Resposta após criar um produto
/// </summary>
public record CriarProdutoResposta(
    int Id,
    string Nome,
    string? Descricao,
    decimal Preco,
    int QuantidadeEstoque,
    int CategoriaId
);

/// <summary>
/// Handler responsável por criar um novo produto
/// </summary>
public class CriarProdutoHandler
{
    private readonly BancoDeDados _bancoDeDados;

    public CriarProdutoHandler(BancoDeDados bancoDeDados)
    {
        _bancoDeDados = bancoDeDados;
    }

    public async Task<(bool Sucesso, string? Erro, CriarProdutoResposta? Produto)> Executar(
        CriarProdutoRequisicao requisicao)
    {
        // Validações básicas
        if (string.IsNullOrWhiteSpace(requisicao.Nome))
        {
            return (false, "O nome do produto é obrigatório.", null);
        }

        if (requisicao.Preco <= 0)
        {
            return (false, "O preço deve ser maior que zero.", null);
        }

        if (requisicao.QuantidadeEstoque < 0)
        {
            return (false, "A quantidade em estoque não pode ser negativa.", null);
        }

        // Verifica se a categoria existe
        var categoriaExiste = await _bancoDeDados.Categorias
            .AnyAsync(c => c.Id == requisicao.CategoriaId);

        if (!categoriaExiste)
        {
            return (false, $"Categoria com ID {requisicao.CategoriaId} não encontrada.", null);
        }

        // Cria o novo produto
        var novoProduto = new Produto
        {
            Nome = requisicao.Nome,
            Descricao = requisicao.Descricao,
            Preco = requisicao.Preco,
            QuantidadeEstoque = requisicao.QuantidadeEstoque,
            CategoriaId = requisicao.CategoriaId
        };

        _bancoDeDados.Produtos.Add(novoProduto);
        await _bancoDeDados.SaveChangesAsync();

        var resposta = new CriarProdutoResposta(
            novoProduto.Id,
            novoProduto.Nome,
            novoProduto.Descricao,
            novoProduto.Preco,
            novoProduto.QuantidadeEstoque,
            novoProduto.CategoriaId
        );

        return (true, null, resposta);
    }
}
