using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Networking.Login;

namespace BusinessLogic.Networking.Login
{
    public class LoginNet : ILoginNet
    {
        private LoginService.LoginServiceClient client;

        public LoginNet(LoginService.LoginServiceClient client)
        {
            this.client = client;
        }
        
        public async Task<User> GetUserLoginAsync(User user)
        {
            var userAsJson = JsonSerializer.Serialize(user);    
            var providerLoginAsync = await client.GetUserLoginAsync(new ProtobufMessage() {MessageOrObject = userAsJson});
            var messageOrObject = providerLoginAsync.MessageOrObject;
            var deserialize = JsonSerializer.Deserialize<User>(messageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }
    }
}