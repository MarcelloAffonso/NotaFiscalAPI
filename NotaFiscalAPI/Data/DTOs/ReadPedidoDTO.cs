using NotaFiscalAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace NotaFiscalAPI.Data.DTOs;

public class ReadPedidoDTO
{
    public double ValorBruto { get; set; }

    public Cliente Cliente { get; set; }

    public ReadNotaFiscalDTO NF { get; set; }

    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
