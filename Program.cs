using EstacionamentoApi.Entities;
using EstacionamentoApi.Repositories;
using EstacionamentoApi.Services;

class Program
{
    static void Main(string[] args)
    {
        ISpotRepository vagaRepository = new SpotRepository();
        List<Spot> vagas = vagaRepository.GetAll();
        SpotService spotService = new SpotService(vagas);

        // Exemplo de uso
        Console.WriteLine($"Total de vagas: {spotService.TotalSpots()}");
        Console.WriteLine($"Vagas restantes: {spotService.TotalRemainingPark()}");
        Console.WriteLine($"Estacionamento cheio: {spotService.FullParking()}");
        Console.WriteLine($"Estacionamento vazio: {spotService.EmptyParking()}");

        Vehicle moto = new Motorcycle { Placa = "ABC1234" };
        Vehicle carro = new Car { Placa = "DEF5678" };
        Vehicle van = new Van { Placa = "GHI9012" };

        spotService.ParkingVehicle(moto);
        spotService.ParkingVehicle(carro);
        spotService.ParkingVehicle(van);

        Console.WriteLine($"Vagas restantes: {spotService.TotalRemainingPark()}");
        Console.WriteLine($"Vagas ocupadas por vans: {spotService.SpotOccupiedByVans()}");
    }
}