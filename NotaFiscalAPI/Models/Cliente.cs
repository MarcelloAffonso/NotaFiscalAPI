using System.ComponentModel.DataAnnotations;

namespace NotaFiscalAPI.Models;

public class Cliente
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O cliente deve ter um nome!")]
    [MaxLength(50, ErrorMessage = "O nome não pode ter mais de 50 caracteres!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O cliente deve ter um endereço!")]
    public Endereco Endereco { get; set; }
}
