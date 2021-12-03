using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

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