using Microsoft.EntityFrameworkCore;
using NotaFiscalAPI.Models;

namespace NotaFiscalAPI.Data;

public class PedidoContext : DbContext
{
    public PedidoContext(DbContextOptions<PedidoContext> opts) : base(opts)
    {
    }

    public DbSet<Pedido> Pedidos { get; set; }
}