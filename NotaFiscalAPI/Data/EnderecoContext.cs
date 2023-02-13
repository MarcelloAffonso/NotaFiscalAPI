using Microsoft.EntityFrameworkCore;
using NotaFiscalAPI.Models;

namespace NotaFiscalAPI.Data;

public class EnderecoContext : DbContext
{
    public EnderecoContext(DbContextOptions<EnderecoContext> opts) : base(opts)
    {
    }

    public DbSet<Endereco> Enderecos { get; set; }
}
