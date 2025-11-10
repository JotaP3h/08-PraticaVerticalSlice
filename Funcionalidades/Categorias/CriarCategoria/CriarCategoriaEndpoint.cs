using Microsoft.AspNetCore.Mvc;

namespace AprendizadoVerticalSlice.Funcionalidades.Categorias.CriarCategoria;

/// <summary>
/// Endpoint para criar uma nova categoria
/// </summary>
public static class CriarCategoriaEndpoint
{
    public static IEndpointRouteBuilder MapCriarCategoria(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/categorias", async (
            [FromBody] CriarCategoriaRequisicao requisicao,
            [FromServices] CriarCategoriaHandler handler) =>
        {
            var (sucesso, erro, categoria) = await handler.Executar(requisicao);

            if (!sucesso)
            {
                return Results.BadRequest(new { mensagem = erro });
            }

            return Results.Created($"/api/categorias/{categoria!.Id}", categoria);
        })
        .WithName("CriarCategoria")
        .WithTags("Categorias")
        .Produces<CriarCategoriaResposta>(201)
        .Produces(400);

        return endpoints;
    }
}
