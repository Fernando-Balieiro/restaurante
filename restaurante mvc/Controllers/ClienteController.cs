using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using restaurante_mvc.Models;
using restaurante_mvc.Repository;

namespace restaurante_mvc.Controllers;

[Route("[controller]")]
[Authorize]
public class ClienteController : Controller
{
    private readonly ClienteRepository _repo;

    public ClienteController(ClienteRepository repo)
    {
        _repo = repo;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _repo.GetAll());
    }

    public async Task<IActionResult> SearchById(Guid? id)
    {
        return id is null ? BadRequest() : View(await _repo.GetById((Guid)id));
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id is null) return BadRequest();

        return View(await _repo.Delete((Guid)id));
    }

    public async Task<IActionResult> CreateCliente(Cliente cliente)
    {
        var clienteCriado = Cliente.create(
            cliente.ClienteId,
            cliente.Nome,
            cliente.Telefone,
            cliente.Endereco
        );

        return View(await _repo.Create(clienteCriado));
    }
}