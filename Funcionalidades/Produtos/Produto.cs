using AprendizadoVerticalSlice.Funcionalidades.Categorias;

namespace AprendizadoVerticalSlice.Funcionalidades.Produtos;

/// <summary>
/// Entidade que representa um Produto
/// </summary>
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
    public int CategoriaId { get; set; }
    
    // Navegação para a categoria
    public Categoria? Categoria { get; set; }
}
