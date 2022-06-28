namespace wsServer.Models;

public class Autor
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string CPF { get; private set; }

    public Autor(int id, string nome, string cPF)
    {
        Id = id;
        Nome = nome;
        CPF = cPF;
    }
}
