using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Microsoft.JSInterop;
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
        
        public async Task<Provider> GetProviderLoginAsync(string email)
        {
            var providerLoginAsync = await client.getProviderLoginAsync(new ProtobufMessage() {MessageOrObject = email});
            var messageOrObject = providerLoginAsync.MessageOrObject;
            var deserialize = JsonSerializer.Deserialize<Provider>(messageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task<Customer> GetCustomerLoginAsync(string email)
        {
            var customerLoginAsync = await client.getCustomerLoginAsync(new ProtobufMessage() {MessageOrObject = email});
            var messageOrObject = customerLoginAsync.MessageOrObject;
            var deserialize = JsonSerializer.Deserialize<Customer>(messageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task<Administrator> AddAdministratorLoginAsync(string email)
        {
            var addAdministratorLoginAsync = await client.addAdministratorLoginAsync(new ProtobufMessage() {MessageOrObject = email});
            var messageOrObject = addAdministratorLoginAsync.MessageOrObject;
            var administrator = JsonSerializer.Deserialize<Administrator>(messageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return administrator;
        }
    }
}