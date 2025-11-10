using Microsoft.AspNetCore.Mvc;

namespace AprendizadoVerticalSlice.Funcionalidades.Produtos.ObterTodosProdutos;

/// <summary>
/// Endpoint para obter todos os produtos
/// Na arquitetura Vertical Slice, cada endpoint fica junto com sua funcionalidade
/// </summary>
public static class ObterTodosProdutosEndpoint
{
    public static IEndpointRouteBuilder MapObterTodosProdutos(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/produtos", async (
            [FromServices] ObterTodosProdutosHandler handler) =>
        {
            var produtos = await handler.Executar();
            return Results.Ok(produtos);
        })
        .WithName("ObterTodosProdutos")
        .WithTags("Produtos")
        .Produces<List<ProdutoResposta>>(200);

        return endpoints;
    }
}
