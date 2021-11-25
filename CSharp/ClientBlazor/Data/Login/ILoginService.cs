using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Login
{
    public interface ILoginService
    {
        Task<User> ValidateUser(User userCred);
    }
}