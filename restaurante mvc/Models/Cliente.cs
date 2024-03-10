using System.ComponentModel.DataAnnotations;

namespace restaurante_mvc.Models;

public class Cliente
{
    private Cliente(Guid clienteId, string nome, string telefone, Endereco endereco)
    {
        ClienteId = clienteId;
        Nome = nome;
        Telefone = telefone;
        Endereco = endereco;
    }

    [Key] public Guid ClienteId { get; }

    [Required(ErrorMessage = "O nome do cliente é obrigatório")]
    [MinLength(5)]
    [MaxLength(50)]
    public string Nome { get; }

    [RegularExpression(@"^\([0-9]{2}\) [0-9]{4,5}\-[0-9]{4}$",
        ErrorMessage = "Formato de telefone inválido. Use (00) 0000-0000 ou (00) 00000-0000.")]
    [StringLength(15, ErrorMessage = "O número do telefone não pode ter mais de 15 caracteres")]
    public string Telefone { get; }

    public Endereco Endereco { get; private set; }

    public static Cliente create(Guid? clienteId,
        string nome,
        string telefone,
        Endereco endereco
    )
    {
        var uuidClienteId = clienteId ?? Guid.NewGuid();

        return new Cliente(uuidClienteId, nome, telefone, endereco);
    }
}