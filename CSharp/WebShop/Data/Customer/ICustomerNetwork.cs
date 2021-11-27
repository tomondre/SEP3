using System.Threading.Tasks;

namespace WebShop.Data.Customer
{
    public interface ICustomerNetwork
    { 
        Task CreateCustomerAsync(GrpcFileGeneration.Models.Customer customer);
    }
}