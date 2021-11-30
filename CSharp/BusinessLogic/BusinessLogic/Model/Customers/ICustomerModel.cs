using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.Customers
{
    public interface ICustomerModel
    {
        Task<User> CreateCustomerAsync(Customer customer);
        Task<IList<Customer>> GetAllCustomersAsync();
        Task DeleteCustomerAsync(int customerId);
    }
}