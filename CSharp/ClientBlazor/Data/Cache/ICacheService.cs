using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Cache
{
    public interface ICacheService
    {
        Task<User> GetCachedUserAsync();
        Task<string> GetCachedTokenAsync();
    }
}