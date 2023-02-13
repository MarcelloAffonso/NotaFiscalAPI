using System.ComponentModel.DataAnnotations;

namespace NotaFiscalAPI.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set;}

    [Required(ErrorMessage = "Código postal é obrigatório para o endereço!")]
    public string CodigoPostal { get; set;}

    [Required(ErrorMessage ="Descrição é obrigatória para o endereço!")]
    public string Descricao { get; set; }

    public string? Complemento { get; set; }
}
