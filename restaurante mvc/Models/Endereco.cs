namespace restaurante_mvc.Models;

public class Endereco
{
    private Endereco(string rua, string numero, string? complemento, string cidade, string estado, string cep)
    {
        Rua = rua;
        Numero = numero;
        Complemento = complemento;
        Cidade = cidade;
        Estado = estado;
        Cep = cep;
    }

    public string Rua { get; set; }
    public string Numero { get; set; }
    public string? Complemento { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }

    public static Endereco create(
        string rua,
        string numero,
        string? complemento,
        string cidade,
        string estado,
        string cep
    )
    {
        return new Endereco(
            rua,
            numero,
            complemento,
            cidade,
            estado,
            cep
        );
    }
}