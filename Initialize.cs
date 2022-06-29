using wsServer.Models;
using wsServer.Repositories.Contracts;

namespace wsServer;

public class Initialize
{
    private readonly IPublicacoesRepository _publicacoesRepository;
    private readonly IAutoresRepository _autoresRepository;

    public Initialize(IPublicacoesRepository publicacoesRepository, IAutoresRepository autoresRepository)
    {
        _publicacoesRepository = publicacoesRepository;
        _autoresRepository = autoresRepository;
    }

    public void Init()
    {
        var autor1 = new Autor(
            "João",
            "12345678910"
        );

        var autor2 = new Autor(
            "Maria",
            "12345678910"
        );

        var autor3 = new Autor(
            "José",
            "12345678910"
        );

        _autoresRepository.Add(autor1);
        _autoresRepository.Add(autor2);
        _autoresRepository.Add(autor3);

        var pulicacao1 = new Publicacao(
            "Um título de teste",
            1,
            100,
            2000
        );
        pulicacao1.AddAutor(autor1);
        pulicacao1.AddAutor(autor2);

        var pulicacao2 = new Publicacao(
            "Um outro título de teste",
            1,
            100,
            2000
        );
        pulicacao2.AddAutor(autor1);
        pulicacao2.AddAutor(autor3);

        var pulicacao3 = new Publicacao(
            "Um título qualquer",
            1,
            100,
            2000
        );        
        pulicacao3.AddAutor(autor1);
        pulicacao3.AddAutor(autor2);
        pulicacao3.AddAutor(autor3);

        _publicacoesRepository.Add(pulicacao1);
        _publicacoesRepository.Add(pulicacao2);
        _publicacoesRepository.Add(pulicacao3);
    }
}
