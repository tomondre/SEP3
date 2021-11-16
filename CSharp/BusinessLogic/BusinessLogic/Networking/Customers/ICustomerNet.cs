using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking.Customers
{
    public interface ICustomerNet
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}