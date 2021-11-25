using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking.Login
{
    public interface ILoginNet
    {
        Task<User> GetUserLoginAsync(User userCred);
    }
}