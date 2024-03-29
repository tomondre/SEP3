using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using User = ClientBlazor.Models.User;

namespace ClientBlazor.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient client;
        private readonly string uri;
        
        

        public LoginService(HttpClient client)
        {
            this.client = client;
            uri = $"{Environment.GetEnvironmentVariable("HOST")}/Login";
        }
        
        public async Task<User> ValidateUser(User userCred)
        {
            var serialize = JsonSerializer.Serialize(userCred);
            var stringContent = new StringContent(serialize, Encoding.UTF8, "application/json");
            var postAsync = await client.PostAsync(uri, stringContent);
            CheckException(postAsync);
            var readAsStringAsync = await postAsync.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<User>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return user;
        }
        
        private void CheckException(HttpResponseMessage task)
        {
            if (!task.IsSuccessStatusCode)
            {
                throw new Exception($"Code: {task.StatusCode}, {task.Content} ");
            }
        }
    }
}