using System.ServiceModel;
using wsServer.Models;
using wsServer.Repositories.Contracts;

namespace wsServer.Services;

[ServiceContract]
public class PublicacoesService
{
    private readonly IPublicacoesRepository _publicacoesRepository;

    public PublicacoesService(IPublicacoesRepository publicacoesRepository)
    {
        _publicacoesRepository = publicacoesRepository;
    }

    [OperationContract]
    public IEnumerable<Publicacao> BuscarPorTitulo(string busca)
    {
        var publicacoes = _publicacoesRepository.ListByBusca(busca);
        return publicacoes;
    }
}
