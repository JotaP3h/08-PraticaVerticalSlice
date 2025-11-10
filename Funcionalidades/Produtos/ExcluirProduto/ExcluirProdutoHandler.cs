using AprendizadoVerticalSlice.Infraestrutura;

namespace AprendizadoVerticalSlice.Funcionalidades.Produtos.ExcluirProduto;

/// <summary>
/// Handler responsável por excluir um produto
/// </summary>
public class ExcluirProdutoHandler
{
    private readonly BancoDeDados _bancoDeDados;

    public ExcluirProdutoHandler(BancoDeDados bancoDeDados)
    {
        _bancoDeDados = bancoDeDados;
    }

    public async Task<(bool Sucesso, string? Erro)> Executar(int id)
    {
        var produto = await _bancoDeDados.Produtos.FindAsync(id);
        
        if (produto == null)
        {
            return (false, $"Produto com ID {id} não encontrado.");
        }

        _bancoDeDados.Produtos.Remove(produto);
        await _bancoDeDados.SaveChangesAsync();

        return (true, null);
    }
}
