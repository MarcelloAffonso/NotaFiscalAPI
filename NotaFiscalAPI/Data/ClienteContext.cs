using Microsoft.EntityFrameworkCore;
using NotaFiscalAPI.Models;

namespace NotaFiscalAPI.Data;

public class ClienteContext : DbContext
{
    public ClienteContext(DbContextOptions<ClienteContext> opts) : base(opts)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
}