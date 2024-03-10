using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using restaurante_mvc.Models;

namespace restaurante_mvc.Infra.Db;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions options, DbSet<Cliente> clientes, DbSet<Pedido> pedidos) : base(options)
    {
        Clientes = clientes;
        Pedidos = pedidos;
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
}