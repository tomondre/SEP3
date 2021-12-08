using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using User = ClientBlazor.Models.User;

namespace ClientBlazor.Data.Cache
{
    public class CacheService : ICacheService
    {
        private ProtectedSessionStorage sessionStorage;

        public CacheService(ProtectedSessionStorage sessionStorage)
        {
            this.sessionStorage = sessionStorage;
        }

        public async Task<User> GetCachedUserAsync()
        {
            var protectedBrowserStorageResult = await sessionStorage.GetAsync<User>("currentUser");
            return protectedBrowserStorageResult.Value;
        }

        public async Task<string> GetCachedTokenAsync()
        {
            var protectedBrowserStorageResult = await sessionStorage.GetAsync<string>("token");
            return protectedBrowserStorageResult.Value;
        }
    }
}