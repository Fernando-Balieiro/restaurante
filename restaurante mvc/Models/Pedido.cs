using System.ComponentModel.DataAnnotations;

namespace restaurante_mvc.Models;

public class Pedido
{
    private Pedido(Guid pedidoId, DateTime dataPedido, string statusPedido, Guid clienteId)
    {
        PedidoId = pedidoId;
        DataPedido = dataPedido;
        StatusPedido = statusPedido;
        ClienteId = clienteId;
    }

    [Key] public Guid PedidoId { get; private set; }
    public DateTime DataPedido { get; private set; }
    public string StatusPedido { get; private set; }
    public Guid ClienteId { get; private set; }

    public static Pedido create(
        Guid? pedidoId,
        DateTime dataPedido,
        string statusPedido,
        Guid clienteId
    )
    {
        var idDoPedido = pedidoId ?? Guid.NewGuid();
        return new Pedido(
            idDoPedido,
            dataPedido,
            statusPedido,
            clienteId
        );
    }
}