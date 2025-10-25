using System.ComponentModel.DataAnnotations;

namespace Projeto_Ascii.Dtos;

public class CriarProdutoDto
{
    [Required, StringLength(50, ErrorMessage = "Nome do produto não pode ter mais de 50 caracteres.")]
    public string Nome { get; set; }
    [Required]
    public decimal Preco { get; set; }
    [Required, StringLength(20, ErrorMessage = "Categoria não pode ter mais de 20 caracteres.")]
    public string Categoria { get; set; }
}