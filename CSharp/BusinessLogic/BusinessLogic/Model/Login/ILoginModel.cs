using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.Login
{
    public interface ILoginModel
    {
        Task<Customer> AuthenticateCustomerAsync(string username, string password); 
        Task<Provider> AuthenticateProviderAsync(string username, string password); 
        Task<Administrator> AuthenticateAdministratorAsync(string username, string password); 
    }
}