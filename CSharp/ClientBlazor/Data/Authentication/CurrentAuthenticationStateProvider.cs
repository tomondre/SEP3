using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using ClientBlazor.Data.Login;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using Networking.User;

namespace ClientBlazor.Data.Authentication
{
    public class CurrentAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILoginService loginService;
        private readonly ProtectedSessionStorage sessionStorage;

        private User cachedUser;
        
        public CurrentAuthenticationStateProvider(ILoginService loginService, ProtectedSessionStorage sessionStorage)
        {
            this.loginService = loginService;
            this.sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (cachedUser == null)
            {
                var userFromStorage = await sessionStorage.GetAsync<User>("currentUser");
                if (userFromStorage.Success)
                {
                    await ValidateUser(userFromStorage.Value);
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
                await sessionStorage.SetAsync("currentUser", user);
                await sessionStorage.SetAsync("token", user.Token);
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
            sessionStorage.SetAsync("currentUser", user);
            sessionStorage.SetAsync("token", "");
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}