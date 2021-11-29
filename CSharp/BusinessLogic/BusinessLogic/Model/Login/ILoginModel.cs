using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.Login
{
    public interface ILoginModel
    {
        Task<User> AuthenticateUserAsync(User userCred); 
    }
}