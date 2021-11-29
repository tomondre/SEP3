using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using WebShop.Services.Login;

namespace WebShop.Data.Authentication
{
    public class CurrentAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRuntime;
        private readonly ILoginService loginService;

        private User cachedUser;
        
        public CurrentAuthenticationStateProvider(IJSRuntime jsRuntime, ILoginService loginService)
        {
            this.jsRuntime = jsRuntime;
            this.loginService = loginService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                string userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
                if (!string.IsNullOrEmpty(userAsJson))
                {
                    User user = JsonSerializer.Deserialize<User>(userAsJson);
                    await ValidateUser(user);
                }
            }
            else
            {
                identity = SetupClaimsForUser(cachedUser);
            }
            
            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        private ClaimsIdentity SetupClaimsForUser(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new(ClaimTypes.Role, user.SecurityType)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims);
            return identity;
        }

        public async Task ValidateUser(User userCred)
        {
            
            if (string.IsNullOrEmpty(userCred.Email)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(userCred.Password)) throw new Exception("Enter password");

            var identity = new ClaimsIdentity();
            try
            {
                var user = await loginService.ValidateUser(userCred);
                identity = SetupClaimsForUser(user);
                string userAsJson = JsonSerializer.Serialize(user);
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", userAsJson);
                cachedUser = user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity))));
        }

        public void Logout()
        {
            cachedUser = null;
            var user = new ClaimsPrincipal(new ClaimsIdentity());
            jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", user);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}