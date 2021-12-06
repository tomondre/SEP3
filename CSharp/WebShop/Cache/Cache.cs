using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using WebShop.Models;

namespace WebShop.Cache
{
    public class Cache:ICache
    {
        private ProtectedSessionStorage sessionStorage;
        
        public Cache(ProtectedSessionStorage sessionStorage)
        {
            this.sessionStorage = sessionStorage;
        }

        public async Task<User> GetCachedUser()
        {
            var protectedBrowserStorageResult = await sessionStorage.GetAsync<User>("currentUser");
            return protectedBrowserStorageResult.Value;
        }

        public async Task<string> GetCachedToken()
        {
            var protectedBrowserStorageResult = await sessionStorage.GetAsync<string>("token");
            return protectedBrowserStorageResult.Value;
        }
    }
}