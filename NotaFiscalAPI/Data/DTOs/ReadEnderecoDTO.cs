using System.ComponentModel.DataAnnotations;

namespace NotaFiscalAPI.Data.DTOs;

public class ReadEnderecoDTO
{
    public string CodigoPostal { get; set; }

    public string Descricao { get; set; }

    public string? Complemento { get; set; }

    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
