using wsServer.Models;

namespace wsServer.Repositories.Contracts;

public interface IPublicacoesRepository
{
    public void Add(Publicacao publicacao);
    public void Update(Publicacao publicacao);
    public void Remove(int id);
    
    public Publicacao? GetById(int id);
    public IEnumerable<Publicacao> ListByBusca(string busca);
}
