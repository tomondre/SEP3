using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace WebShop.Cache
{
    public interface ICache
    {
        Task<User> GetCachedUser();
        Task<string> GetCachedToken();
    }
}