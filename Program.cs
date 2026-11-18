
using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        // 1. Criando um objeto Drone
        DroneStatus drone = new DroneStatus
        {
            CodigoIdentificador = "DRONE001",
            NivelBateria = 85,
            Latitude = -19.9167,
            Longitude = -43.9345,
            EmMissao = true
        };

        // 2. Serialização: transformando o objeto em JSON
        string json = JsonSerializer.Serialize(
            drone,
            new JsonSerializerOptions { WriteIndented = true }
        );

        // 3. Salvando o JSON em um arquivo
        File.WriteAllText("status_drone.json", json);

        Console.WriteLine("Arquivo JSON criado com sucesso!");

        // 4. Lendo o arquivo JSON
        string arquivo = File.ReadAllText("status_drone.json");

        // 5. Desserialização: reconstruindo o objeto
        DroneStatus droneLido =
            JsonSerializer.Deserialize<DroneStatus>(arquivo);

        // 6. Exibindo os dados no console
        Console.WriteLine("\n===== STATUS DO DRONE =====");

        Console.WriteLine("Código: " + droneLido.CodigoIdentificador);
        Console.WriteLine("Bateria: " + droneLido.NivelBateria + "%");
        Console.WriteLine("Latitude: " + droneLido.Latitude);
        Console.WriteLine("Longitude: " + droneLido.Longitude);
        Console.WriteLine("Em missão: " + droneLido.EmMissao);
    }
}
