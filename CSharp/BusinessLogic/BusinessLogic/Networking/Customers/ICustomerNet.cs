using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking.Customers
{
    public interface ICustomerNet
    {
        Task<User> CreateCustomerAsync(Customer customer);
        Task<Page<CustomerList>> GetAllCustomersAsync(int pageRequest);
        Task DeleteCustomerAsync(int customerId);
        Task<Page<CustomerList>> FindCustomerByNameAsync(string name, int pageRequest);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> EditCustomerAsync(Customer customer);
    }
}