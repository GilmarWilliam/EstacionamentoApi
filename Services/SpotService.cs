using EstacionamentoApi.Entities;
using EstacionamentoApi.Enums;

namespace EstacionamentoApi.Services
{
    public class SpotService
    {
        private List<Spot> Spots;

        public SpotService(List<Spot> spots)
        {
            Spots = spots;
        }

        public int TotalSpots()
        {
            return Spots.Count;
        }

        public int TotalRemainingPark()
        {
            return Spots.Count(x => x.FreeSpotParking());
        }

        public bool FullParking()
        {
            return Spots.All(x => !x.FreeSpotParking());
        }

        public bool EmptyParking()
        {
            return Spots.All(x => x.FreeSpotParking());
        }

        public int SpotsOccupiedByType(SpotTypeEnum vehicleType)
        {
            return Spots.Count(x => x.Type == vehicleType && !x.FreeSpotParking());
        }

        public int SpotOccupiedByVans()
        {
            return Spots.Count(x => x.ParkedVehicle is Van);
        }

        public bool ParkingVehicle(Vehicle vehicle)
        {
            switch(vehicle)
            {
                case Motorcycle: 
                    return ParkInFirstFreeSpot(vehicle, SpotTypeEnum.Motorcycle) ||
                           ParkInFirstFreeSpot(vehicle, SpotTypeEnum.Car) ||
                           ParkInFirstFreeSpot(vehicle, SpotTypeEnum.Van);
                case Car:
                    return ParkInFirstFreeSpot(vehicle, SpotTypeEnum.Car) || 
                           ParkInFirstFreeSpot(vehicle, SpotTypeEnum.Van);
                case Van:
                    if(ParkInFirstFreeSpot(vehicle, SpotTypeEnum.Van))
                        return true;
                    else
                        return ParkingVanInCarSpot();
                default:
                    return false;
            }
        }

        public bool ParkInFirstFreeSpot(Vehicle vehicle, SpotTypeEnum spotType)
        {
            var freeSpot = Spots.FirstOrDefault(x => x.Type == spotType && x.FreeSpotParking());
            if(freeSpot != null)
            {
                freeSpot.ParkingVehicle(vehicle);
                return true;
            }
            return false;
        }

        private bool ParkingVanInCarSpot()
        {
            var freeSpots = Spots.Where(x => x.Type == SpotTypeEnum.Car && x.FreeSpotParking()).Take(3).ToList();
            if(freeSpots.Count == 3)
            {
                foreach (var spot in freeSpots)
                {
                    spot.ParkingVehicle(new Van());
                }
                return true;
            }
            return false;
        }
    }
}