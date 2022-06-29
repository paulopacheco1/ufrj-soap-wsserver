using wsServer.Models;
using wsServer.Repositories.Contracts;

namespace wsServer.Repositories.InMemory;

public class InMemoryPublicacoesRepository : IPublicacoesRepository
{
    private List<Publicacao> _entityColection;
    private int _nextId;

    private readonly IAutoresRepository _autoresRepository;

    public InMemoryPublicacoesRepository(IAutoresRepository autoresRepository)
    {
        _entityColection = new List<Publicacao>();
        _nextId = 1;

        _autoresRepository = autoresRepository;
    }

    public void Add(Publicacao publicacao)
    {
        publicacao.GetType().GetProperty("Id")?.SetValue(publicacao, _nextId++);
        _entityColection.Add(publicacao);
    }

    public void Update(Publicacao publicacao)
    {
        var stored = _entityColection.Find(obj => obj.Id == publicacao.Id);
        if (stored == null) throw new ApplicationException("Publicação não encontrada.");

        stored = publicacao;
    }

    public void Remove(int id)
    {
        var stored = _entityColection.Find(obj => obj.Id == id);
        if (stored == null) throw new ApplicationException("Publicação não encontrada.");

        _entityColection.Remove(stored);
    }

    public Publicacao? GetById(int id)
    {
        var publicacao = _entityColection.Find(obj => obj.Id == id);
        if (publicacao == null) return null;

        var autoresIds = publicacao.Autores.Select(autor => autor.Id);
        var autores = _autoresRepository.ListAll().Where(autor => autoresIds.Contains(autor.Id));

        publicacao.GetType().GetProperty("Autores")?.SetValue(publicacao, autores);

        return publicacao;
    }

    public IEnumerable<Publicacao> ListByBusca(string busca)
    {
        return _entityColection.FindAll(obj => obj.Titulo.Contains(busca)).AsReadOnly();
    }
}
