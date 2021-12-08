using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using User = ClientBlazor.Models.User;

namespace ClientBlazor.Data.Login
{
    public interface ILoginService
    {
        Task<User> ValidateUser(User userCred);
    }
}