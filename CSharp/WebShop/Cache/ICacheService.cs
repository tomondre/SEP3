using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Cache
{
    public interface ICacheService
    {
        Task<User> GetCachedUserAsync();
        Task<string> GetCachedTokenAsync();
    }
}