using System;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace GrpcFileGeneration.Models
{
    public class CurrentUser
    {
        public Administrator Administrator { set; get; }
        public Provider Provider { set; get; }
        public Customer Customer { set; get; }
        private readonly IJSRuntime jsRuntime;

        public CurrentUser(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task CacheUserAsync<T>(T userToCache)
        {
            var jsonUser = JsonSerializer.Serialize(userToCache);
            if (userToCache is Administrator)
            {
                var user = (Administrator)Convert.ChangeType(userToCache, typeof(T));
                Administrator = user;
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUserAdministrator", jsonUser);

            }
            else if (userToCache is Provider)
            {
                var user = (Provider)Convert.ChangeType(userToCache, typeof(T));
                Provider = user;
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUserProvider", jsonUser);
            }

        }
    }
}