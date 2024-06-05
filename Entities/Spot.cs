using EstacionamentoApi.Enums;

namespace EstacionamentoApi.Entities
{
    public class Spot
    {
        public int Number { get; set; }
        public SpotTypeEnum Type { get; set; }
        public Vehicle? ParkedVehicle { get; set; }

        public bool FreeSpotParking()
        {
            return ParkedVehicle == null;
        }

        public void ParkingVehicle(Vehicle vehicle)
        {
            ParkedVehicle = vehicle;
        }

        public void RemoveVehicle()
        {
            ParkedVehicle = null;
        }
    }
}