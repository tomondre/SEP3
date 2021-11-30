using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Customers
{
    public interface ICustomerService
    {
        Task<CustomerList> GetAllCustomers();
        Task DeleteCustomer(Customer customer);
    }
}