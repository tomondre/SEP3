using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace WebShop.RestWebShop
{
    public interface ICustomerNetwork
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}