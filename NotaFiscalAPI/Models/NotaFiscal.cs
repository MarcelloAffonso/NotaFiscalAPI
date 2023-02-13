using NotaFiscalAPI.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace NotaFiscalAPI.Models;

public class NotaFiscal
{
    [Key]
    [Required]
    public int Id { get; set; }

    public double ValorComImpostosAplicados { get; set;}
}
