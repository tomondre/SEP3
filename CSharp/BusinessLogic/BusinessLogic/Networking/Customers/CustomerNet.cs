using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Networking.Customer;

namespace BusinessLogic.Networking.Customers
{
    public class CustomerNet : ICustomerNet
    {

        private CustomerService.CustomerServiceClient client;

        public CustomerNet(CustomerService.CustomerServiceClient client)
        {
            this.client = client;
        }
        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            var serialize = JsonSerializer.Serialize(customer);
            var protobufMessage = await client.createCustomerAsync(new ProtobufMessage(){MassageOrObject = serialize});
            return JsonSerializer.Deserialize<Customer>(protobufMessage.MassageOrObject, new JsonSerializerOptions(){PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }
    }
}