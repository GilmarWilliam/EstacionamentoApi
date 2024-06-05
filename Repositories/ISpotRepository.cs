using EstacionamentoApi.Entities;

namespace EstacionamentoApi.Repositories
{
    public interface ISpotRepository
    {
        List<Spot>GetAll();
    }
}