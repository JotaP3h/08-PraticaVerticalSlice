using Microsoft.AspNetCore.Mvc;

namespace AprendizadoVerticalSlice.Funcionalidades.Produtos.CriarProduto;

/// <summary>
/// Endpoint para criar um novo produto
/// </summary>
public static class CriarProdutoEndpoint
{
    public static IEndpointRouteBuilder MapCriarProduto(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/produtos", async (
            [FromBody] CriarProdutoRequisicao requisicao,
            [FromServices] CriarProdutoHandler handler) =>
        {
            var (sucesso, erro, produto) = await handler.Executar(requisicao);

            if (!sucesso)
            {
                return Results.BadRequest(new { mensagem = erro });
            }

            return Results.Created($"/api/produtos/{produto!.Id}", produto);
        })
        .WithName("CriarProduto")
        .WithTags("Produtos")
        .Produces<CriarProdutoResposta>(201)
        .Produces(400);

        return endpoints;
    }
}
