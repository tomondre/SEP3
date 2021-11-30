using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Cache
{
    public interface ICacheService
    {
        Task<User> GetCachedUser();
        Task<string> GetCachedToken();
    }
}