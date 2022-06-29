using wsServer.Models;

namespace wsServer.Repositories.Contracts;

public interface IAutoresRepository
{
    public void Add(Autor autor);
    public void Update(Autor autor);
    public void Remove(int id);
    
    public Autor? GetById(int id);
    public IEnumerable<Autor> ListAll();
}
