using System.ComponentModel.DataAnnotations;


namespace Projeto_Ascii.Models;

public class Produto
{
    [Key]
    public Guid Id { get; set; }
    [Required, MaxLength(50, ErrorMessage = "Nome do produto não pode ter mais de 50 caracteres.")]
    public string Nome { get; set; }
    [Required]
    public decimal Preco { get; set; }
    [Required, MaxLength(20, ErrorMessage = "Categoria não pode ter mais de 20 caracteres.")]
    public string Categoria { get; set; }
}