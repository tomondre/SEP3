using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace WebShop.Services.Login
{
    public interface ILoginService
    {
        Task<User> ValidateUser(User userCred);
    }
}