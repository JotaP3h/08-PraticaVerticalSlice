using Microsoft.AspNetCore.Mvc;

namespace AprendizadoVerticalSlice.Funcionalidades.Produtos.ExcluirProduto;

/// <summary>
/// Endpoint para excluir um produto
/// </summary>
public static class ExcluirProdutoEndpoint
{
    public static IEndpointRouteBuilder MapExcluirProduto(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapDelete("/api/produtos/{id:int}", async (
            [FromRoute] int id,
            [FromServices] ExcluirProdutoHandler handler) =>
        {
            var (sucesso, erro) = await handler.Executar(id);

            if (!sucesso)
            {
                return Results.NotFound(new { mensagem = erro });
            }

            return Results.NoContent();
        })
        .WithName("ExcluirProduto")
        .WithTags("Produtos")
        .Produces(204)
        .Produces(404);

        return endpoints;
    }
}
