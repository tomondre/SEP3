using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Login
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient client;
        private readonly string uri;
        
        

        public LoginService(HttpClient client)
        {
            this.client = client;
            uri = "https://localhost:5001/Login/authenticate";
        }
        
        public async Task<Administrator> LoginAdministrator(GrpcFileGeneration.Models.Login login)
        {
            var serialize = JsonSerializer.Serialize(login);
            var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
            var postAsync = await client.PostAsync($"{uri}/administrator", stringContent);
            var readAsStringAsync = await postAsync.Content.ReadAsStringAsync();
            var administrator = JsonSerializer.Deserialize<Administrator>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return administrator;
        }

        public async Task<Provider> LoginProvider(GrpcFileGeneration.Models.Login login)
        {
            var serialize = JsonSerializer.Serialize(login);
            var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
            var postAsync = await client.PostAsync($"{uri}/provider", stringContent);
            var readAsStringAsync = await postAsync.Content.ReadAsStringAsync();
            var provider = JsonSerializer.Deserialize<Provider>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return provider;
        }
    }
}