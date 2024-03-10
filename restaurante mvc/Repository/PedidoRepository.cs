using Microsoft.EntityFrameworkCore;
using restaurante_mvc.Infra.Db;
using restaurante_mvc.Models;

namespace restaurante_mvc.Repository;

public class PedidoRepository : IAbstractRepository<Pedido, Guid>
{
    public readonly AppDbContext Ctx;

    public PedidoRepository(AppDbContext ctx)
    {
        Ctx = ctx;
    }

    public async Task<List<Pedido>> GetAll()
    {
        return await Ctx.Pedidos.ToListAsync();
    }

    public async Task<Pedido?> GetById(Guid id)
    {
        return await Ctx.Pedidos.FirstOrDefaultAsync(p => p.PedidoId == id);
    }

    public async Task<Pedido> Create(Pedido entity)
    {
        var creatingPedido = Pedido.create(
            entity.PedidoId,
            entity.DataPedido,
            entity.StatusPedido,
            entity.ClienteId
        );

        Ctx.Pedidos.Add(creatingPedido);
        await Ctx.SaveChangesAsync();
        return creatingPedido;
    }

    public async Task<string> Delete(Guid id)
    {
        var getDeletingPedido = await Ctx.Pedidos.FirstOrDefaultAsync(p => p.PedidoId == id);
        if (getDeletingPedido is null) return $"nenhum pedido com id {id} foi encontrado";

        Ctx.Pedidos.Remove(getDeletingPedido);
        await Ctx.SaveChangesAsync();
        return $"Pedido com id {id} apagado";
    }
}