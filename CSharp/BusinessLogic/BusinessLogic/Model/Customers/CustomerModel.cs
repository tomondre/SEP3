using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Networking.Customers;
using GrpcFileGeneration.Models;


// TODO data validation
namespace BusinessLogic.Model.Customers
{
    public class CustomerModel : ICustomerModel
    {
        private ICustomerNet network;

        public CustomerModel(ICustomerNet network)
        {
            this.network = network;
        }
        
        public Task<User> CreateCustomerAsync(Customer customer)
        {
            return network.CreateCustomerAsync(customer);
        }

        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            return await network.GetAllCustomersAsync();
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            await network.DeleteCustomerAsync(customerId);
        }
    }
}