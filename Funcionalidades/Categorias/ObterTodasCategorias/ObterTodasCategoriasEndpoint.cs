using Microsoft.AspNetCore.Mvc;

namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.ObterTodasCategorias;

/// <summary>
/// Endpoint para obter todas as categorias
/// </summary>
public static class ObterTodasCategoriasEndpoint
{
    public static IEndpointRouteBuilder MapObterTodasCategorias(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/categorias", async (
            [FromServices] ObterTodasCategoriasHandler handler) =>
        {
            var categorias = await handler.Executar();
            return Results.Ok(categorias);
        })
        .WithName("ObterTodasCategorias")
        .WithTags("Categorias")
        .Produces<List<CategoriaResposta>>(200);

        return endpoints;
    }
}
