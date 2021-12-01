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