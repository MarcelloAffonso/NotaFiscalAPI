using System.ComponentModel.DataAnnotations;

namespace NotaFiscalAPI.Models;

public class Pedido
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Pedido deve possuir um valor bruto!")]
    public double ValorBruto { get; set; }

    [Required(ErrorMessage = "O pedido deve possuir um cliente associado!")]
    public Cliente Cliente { get; set; }

    public NotaFiscal? NF { get; set; }
}
