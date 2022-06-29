using System.Runtime.Serialization;

namespace wsServer.Models;

[DataContract]
public class Publicacao
{
    [DataMember]
    public int Id { get; private set; }
    [DataMember]
    public string Titulo { get; private set; }
    [DataMember]
    public int PaginaInicial { get; private set; }
    [DataMember]
    public int PaginaFinal { get; private set; }
    [DataMember]
    public int AnoPublicacao { get; private set; }
    [DataMember]
    public ICollection<Autor> Autores { get; private set; }

    public Publicacao()
    {
    }

    public Publicacao(string titulo, int paginaInicial, int paginaFinal, int anoPublicacao)
    {
        Titulo = titulo;
        PaginaInicial = paginaInicial;
        PaginaFinal = paginaFinal;
        AnoPublicacao = anoPublicacao;
        Autores = new List<Autor>();
    }

    public void AddAutor(Autor autor)
    {
        Autores?.Add(autor);
    }
}
