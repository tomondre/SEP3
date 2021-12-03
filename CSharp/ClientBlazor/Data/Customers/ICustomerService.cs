using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Customers
{
    public interface ICustomerService
    {
        Task<CustomerList> GetAllCustomersAsync();
        Task DeleteCustomer(Customer customer);
        Task<CustomerList> GetAllCustomersByNameAsync(string name);
    }
}