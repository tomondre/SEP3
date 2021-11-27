using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace WebShop.Data.Login
{
    public interface ILoginService
    {
        Task<User> ValidateUser(User userCred);
    }
}