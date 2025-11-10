using Microsoft.EntityFrameworkCore;
using AprendizadoVerticalSlice.Infraestrutura;

namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.ObterTodasCategorias;

/// <summary>
/// Resposta contendo os dados de uma categoria
/// </summary>
public record CategoriaResposta(
    int Id,
    string Nome,
    string? Descricao
);

/// <summary>
/// Handler responsável por obter todas as categorias
/// </summary>
public class ObterTodasCategoriasHandler
{
    private readonly BancoDeDados _bancoDeDados;

    public ObterTodasCategoriasHandler(BancoDeDados bancoDeDados)
    {
        _bancoDeDados = bancoDeDados;
    }

    public async Task<List<CategoriaResposta>> Executar()
    {
        var categorias = await _bancoDeDados.Categorias
            .Select(c => new CategoriaResposta(c.Id, c.Nome, c.Descricao))
            .ToListAsync();

        return categorias;
    }
}
