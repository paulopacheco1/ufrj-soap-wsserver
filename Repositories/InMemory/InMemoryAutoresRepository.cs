using wsServer.Models;
using wsServer.Repositories.Contracts;

namespace wsServer.Repositories.InMemory;

public class InMemoryAutoresRepository : IAutoresRepository
{
    private List<Autor> _entityColection;
    private int _nextId;

    public InMemoryAutoresRepository()
    {
        _entityColection = new List<Autor>();
        _nextId = 1;
    }

    public void Add(Autor autor)
    {
        autor.GetType().GetProperty("Id")?.SetValue(autor, _nextId++);
        _entityColection.Add(autor);
    }

    public void Update(Autor autor)
    {
        var stored = _entityColection.Find(obj => obj.Id == autor.Id);
        if (stored == null) throw new ApplicationException("Autor não encontrado.");

        stored = autor;
    }

    public void Remove(int id)
    {
        var stored = _entityColection.Find(obj => obj.Id == id);
        if (stored == null) throw new ApplicationException("Autor não encontrado.");

        _entityColection.Remove(stored);
    }

    public Autor? GetById(int id)
    {
        return _entityColection.Find(obj => obj.Id == id);
    }

    public IEnumerable<Autor> ListAll()
    {
        return _entityColection.AsReadOnly();
    }
}
