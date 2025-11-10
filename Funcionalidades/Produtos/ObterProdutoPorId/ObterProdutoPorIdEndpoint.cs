using Microsoft.AspNetCore.Mvc;

namespace AprendizadoVerticalSlice.Funcionalidades.Produtos.ObterProdutoPorId;

/// <summary>
/// Endpoint para obter um produto específico por ID
/// </summary>
public static class ObterProdutoPorIdEndpoint
{
    public static IEndpointRouteBuilder MapObterProdutoPorId(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/produtos/{id:int}", async (
            [FromRoute] int id,
            [FromServices] ObterProdutoPorIdHandler handler) =>
        {
            var produto = await handler.Executar(id);
            
            if (produto == null)
            {
                return Results.NotFound(new { mensagem = $"Produto com ID {id} não encontrado." });
            }

            return Results.Ok(produto);
        })
        .WithName("ObterProdutoPorId")
        .WithTags("Produtos")
        .Produces<ProdutoResposta>(200)
        .Produces(404);

        return endpoints;
    }
}
