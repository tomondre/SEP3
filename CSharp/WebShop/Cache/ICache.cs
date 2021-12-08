using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Cache
{
    public interface ICache
    {
        Task<User> GetCachedUser();
        Task<string> GetCachedToken();
    }
}