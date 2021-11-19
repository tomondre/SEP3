using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking.Login
{
    public interface ILoginNet
    {
        Task<Provider> GetProviderLoginAsync(string email);
        Task<Customer> GetCustomerLoginAsync(string email);
        Task<Administrator> AddAdministratorLoginAsync(string email);
    }
}