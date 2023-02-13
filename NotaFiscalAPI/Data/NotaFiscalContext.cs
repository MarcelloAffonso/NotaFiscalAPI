using Microsoft.EntityFrameworkCore;
using NotaFiscalAPI.Models;

namespace NotaFiscalAPI.Data;

public class NotaFiscalContext : DbContext
{
    public NotaFiscalContext(DbContextOptions<NotaFiscalContext> opts) : base(opts)
    {
    }

    public DbSet<NotaFiscal> NotasFiscais { get; set; }
}
