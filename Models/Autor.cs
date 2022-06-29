using System.Runtime.Serialization;

namespace wsServer.Models;

[DataContract]
public class Autor
{
    [DataMember]
    public int Id { get; private set; }
    [DataMember]
    public string Nome { get; private set; }
    [DataMember]
    public string CPF { get; private set; }

    public Autor()
    {
    }

    public Autor(string nome, string cpf)
    {
        Nome = nome;
        CPF = cpf;
    }
}
