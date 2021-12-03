using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Customers
{
    public interface ICustomerService
    {
        Task<Page<CustomerList>> GetAllCustomersAsync(int pageNumber);
        Task DeleteCustomer(Customer customer);
        Task<Page<CustomerList>> GetAllCustomersByNameAsync(string name, int pageNumber);
    }
}