using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.Customers
{
    public interface ICustomerModel
    {
        Task<User> CreateCustomerAsync(Customer customer);
        Task<Page<CustomerList>> GetAllCustomersAsync(int pageRequest);
        Task DeleteCustomerAsync(int customerId);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> EditCustomerAsync(Customer customer);
        Task<Page<CustomerList>> FindCustomerByNameAsync(string name, int pageRequest);
    }
}