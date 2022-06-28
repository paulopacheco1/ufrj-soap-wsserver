namespace wsServer.Models;

public class Publicacao
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public int PaginaInicial { get; private set; }
    public int PaginaFinal { get; private set; }
    public int AnoPublicacao { get; private set; }
    public ICollection<Autor> Autores { get; private set; }

    public Publicacao(int id, string titulo, int paginaInicial, int paginaFinal, int anoPublicacao, ICollection<Autor> autores)
    {
        Id = id;
        Titulo = titulo;
        PaginaInicial = paginaInicial;
        PaginaFinal = paginaFinal;
        AnoPublicacao = anoPublicacao;
        Autores = autores;
    }
}
