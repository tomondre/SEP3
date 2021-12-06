using System.Threading.Tasks;
namespace WebShop.Services.Customer
{
    public interface ICustomerService
    { 
        Task CreateCustomerAsync(Models.Customer customer);
        Task<Models.Customer> GetCustomerByIdAsync(int id);
        Task<Models.Customer> EditCustomerAsync(Models.Customer customer);
    }
}