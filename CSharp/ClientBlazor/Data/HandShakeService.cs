using System.Net.Http;
using System.Text.Json;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data
{
    public class HandShakeService : IHandShakeService
    {
        public HandShake HandShake { get; set; }

        public HandShakeService(HttpClient client)
        {
            CreateHandShake(client);
        }
        
        public async void CreateHandShake(HttpClient client)
        {
            
            var httpResponseMessage = await client.GetAsync("https://localhost:5001/Link");
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            HandShake = JsonSerializer.Deserialize<HandShake>(readAsStringAsync);
        }
    }
}