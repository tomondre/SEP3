using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using User = ClientBlazor.Models.User;

namespace ClientBlazor.Data.Cache
{
    public interface ICacheService
    {
        Task<User> GetCachedUserAsync();
        Task<string> GetCachedTokenAsync();
    }
}