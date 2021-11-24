using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Login
{
    public interface ILoginService
    {
        Task<User> LoginAdministrator(GrpcFileGeneration.Models.Login login);
        Task<User> LoginProvider(GrpcFileGeneration.Models.Login login);
    }
}