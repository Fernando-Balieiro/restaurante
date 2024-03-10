using Microsoft.EntityFrameworkCore;
using restaurante_mvc.Infra.Db;
using restaurante_mvc.Models;

namespace restaurante_mvc.Repository;

public class ClienteRepository : IAbstractRepository<Cliente, Guid>
{
    private readonly AppDbContext _ctx;

    public ClienteRepository(AppDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<Cliente>> GetAll()
    {
        return await _ctx.Clientes.ToListAsync();
    }

    public async Task<Cliente> Create(Cliente entity)
    {
        var creatingEntity = Cliente.create(
            entity.ClienteId,
            entity.Nome,
            entity.Telefone,
            entity.Endereco
        );

        _ctx.Clientes.Add(creatingEntity);
        await _ctx.SaveChangesAsync();
        return creatingEntity;
    }

    public async Task<string> Delete(Guid id)
    {
        var deletedCliente = await _ctx.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id);

        if (deletedCliente is null) return $"Nenhum cliente encontrado com id {id}";
        _ctx.Remove(deletedCliente);
        await _ctx.SaveChangesAsync();
        return $"Cliente com id {id} apagado";
    }

    public Task<Cliente?> GetById(Guid id)
    {
        return _ctx.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id);
    }
}