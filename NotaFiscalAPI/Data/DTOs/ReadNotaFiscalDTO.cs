using NotaFiscalAPI.Models.Enum;

namespace NotaFiscalAPI.Data.DTOs;

public class ReadNotaFiscalDTO
{
    public double ValorComImpostosAplicados { get; set; }

    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
}
