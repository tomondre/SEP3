using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Networking.Customer;
using Networking.User;

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

        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            CustomersMessage response = await client.GetAllCustomersAsync(new UserMessage());
            var customersMessage = response.Customers;
            var customers = customersMessage.Select(a => new Customer(a)).ToList();
            return customers;
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
           await client.DeleteCustomerAsync(new UserMessage() {Id = customerId});
        }
    }
}