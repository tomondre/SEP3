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
            var protobufMessage = await client.createCustomerAsync(customerMessage);
            var user = new User(protobufMessage);
            return user;
        }

        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            CustomersMessage response = await client.getAllCustomersAsync(new UserMessage());
            var customersMessage = response.Customers;
            var customers = customersMessage.Select(a => new Customer(a)).ToList();
            return customers;
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
           await client.deleteCustomerAsync(new UserMessage() {Id = customerId});
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            UserMessage userMessage = new UserMessage(){Id = id};
            CustomerMessage customerByIdMessage = await client.getCustomerByIdAsync(userMessage);
            Customer customerById = new Customer(customerByIdMessage);
            return customerById;
        }

        public async Task<Customer> EditCustomerAsync(Customer customer)
        {
            CustomerMessage editedCustomer = await client.editCustomerAsync(customer.ToMessage());
            return new Customer(editedCustomer);

        }

        public async Task<IList<Customer>> FindCustomerByNameAsync(string name)
        {
            var userMessage = new UserMessage() {Email = name};
            var findCustomerByNameAsync = await client.FindCustomerByNameAsync(userMessage);
            var customerMessages = findCustomerByNameAsync.Customers;
            var customers = customerMessages.Select(a => new Customer(a)).ToList();
            return customers;
        }
    }
}