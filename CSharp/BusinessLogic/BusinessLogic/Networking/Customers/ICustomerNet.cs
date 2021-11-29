using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking.Customers
{
    public interface ICustomerNet
    {
        Task<User> CreateCustomerAsync(Customer customer);
        Task<IList<Customer>> GetAllCustomersAsync();
        Task DeleteCustomerAsync(int customerId);
    }
}