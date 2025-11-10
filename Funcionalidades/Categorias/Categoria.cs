namespace AprendizadoVerticalSlice.Funcionalidades.Categorias;

/// <summary>
/// Entidade que representa uma Categoria de produtos
/// </summary>
public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Descricao { get; set; }
}
