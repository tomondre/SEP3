using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace WebShop.RestWebShop
{
    public interface ICustomerService
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}