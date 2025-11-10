using AprendizadoVerticalSlice.Infraestrutura;

namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.CriarCategoria;

/// <summary>
/// Requisição para criar uma nova categoria
/// </summary>
public record CriarCategoriaRequisicao(
    string Nome,
    string? Descricao
);

/// <summary>
/// Resposta após criar uma categoria
/// </summary>
public record CriarCategoriaResposta(
    int Id,
    string Nome,
    string? Descricao
);

/// <summary>
/// Handler responsável por criar uma nova categoria
/// </summary>
public class CriarCategoriaHandler
{
    private readonly BancoDeDados _bancoDeDados;

    public CriarCategoriaHandler(BancoDeDados bancoDeDados)
    {
        _bancoDeDados = bancoDeDados;
    }

    public async Task<(bool Sucesso, string? Erro, CriarCategoriaResposta? Categoria)> Executar(
        CriarCategoriaRequisicao requisicao)
    {
        // Validação básica
        if (string.IsNullOrWhiteSpace(requisicao.Nome))
        {
            return (false, "O nome da categoria é obrigatório.", null);
        }

        // Cria a nova categoria
        var novaCategoria = new Categoria
        {
            Nome = requisicao.Nome,
            Descricao = requisicao.Descricao
        };

        _bancoDeDados.Categorias.Add(novaCategoria);
        await _bancoDeDados.SaveChangesAsync();

        var resposta = new CriarCategoriaResposta(
            novaCategoria.Id,
            novaCategoria.Nome,
            novaCategoria.Descricao
        );

        return (true, null, resposta);
    }
}
