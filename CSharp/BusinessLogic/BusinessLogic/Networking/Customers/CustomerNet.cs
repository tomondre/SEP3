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

        public async Task<User> CreateCustomerAsync(Customer customer)
        {
            CustomerMessage customerMessage = new CustomerMessage(customer.ToMessage());
            var protobufMessage = await client.CreateCustomerAsync(customerMessage);
            var user = new User(protobufMessage);
            return user;
        }
    }
}