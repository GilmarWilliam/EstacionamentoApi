using EstacionamentoApi.Entities;
using EstacionamentoApi.Enums;

namespace EstacionamentoApi.Repositories
{
    public class SpotRepository : ISpotRepository
    {
        private List<Spot> Spots;

        public SpotRepository()
        {
            Spots = new List<Spot>
            {
                new Spot {Number = 1, Type = SpotTypeEnum.Motorcycle},
                new Spot {Number = 2, Type = SpotTypeEnum.Car},
                new Spot {Number = 3, Type = SpotTypeEnum.Van}
            };
        }

        public List<Spot>GetAll()
        {
            return Spots;
        }
    }
}