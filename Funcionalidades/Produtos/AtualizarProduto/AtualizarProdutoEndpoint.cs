using Microsoft.AspNetCore.Mvc;

namespace AprendizadoVerticalSlice.Funcionalidades.Produtos.AtualizarProduto;

/// <summary>
/// Endpoint para atualizar um produto existente
/// </summary>
public static class AtualizarProdutoEndpoint
{
    public static IEndpointRouteBuilder MapAtualizarProduto(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPut("/api/produtos/{id:int}", async (
            [FromRoute] int id,
            [FromBody] AtualizarProdutoRequisicao requisicao,
            [FromServices] AtualizarProdutoHandler handler) =>
        {
            var (sucesso, erro) = await handler.Executar(id, requisicao);

            if (!sucesso)
            {
                return Results.BadRequest(new { mensagem = erro });
            }

            return Results.NoContent();
        })
        .WithName("AtualizarProduto")
        .WithTags("Produtos")
        .Produces(204)
        .Produces(400);

        return endpoints;
    }
}
