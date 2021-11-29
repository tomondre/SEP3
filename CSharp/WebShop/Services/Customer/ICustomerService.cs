using System.Threading.Tasks;

namespace WebShop.Services.Customer
{
    public interface ICustomerService
    { 
        Task CreateCustomerAsync(GrpcFileGeneration.Models.Customer customer);
    }
}