using NotaFiscalAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace NotaFiscalAPI.Data.DTOs;

public class CreatePedidoDTO
{
    [Required(ErrorMessage = "Pedido deve possuir um valor bruto!")]
    public double ValorBruto { get; set; }

    [Required(ErrorMessage = "O pedido deve possuir um cliente associado!")]
    public Cliente Cliente { get; set; }

}
