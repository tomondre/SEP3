using System.Threading.Tasks;
using GrpcFileGeneration.Models;
namespace WebShop.Services.Customer
{
    public interface ICustomerService
    { 
        Task CreateCustomerAsync(GrpcFileGeneration.Models.Customer customer);
        Task<GrpcFileGeneration.Models.Customer> GetCustomerByIdAsync(int id);
        Task<GrpcFileGeneration.Models.Customer> EditCustomerAsync(GrpcFileGeneration.Models.Customer customer);
    }
}