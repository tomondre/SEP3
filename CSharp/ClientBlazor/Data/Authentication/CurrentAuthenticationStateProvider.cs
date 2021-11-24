using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using ClientBlazor.Data.Login;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace ClientBlazor.Data.Authentication
{
    public class CurrentAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime jsRuntime;
        private readonly ILoginService loginService;
        private CurrentUser currentUser;

        public CurrentAuthenticationStateProvider(IJSRuntime jsRuntime, ILoginService loginService, CurrentUser currentUser)
        {
            this.jsRuntime = jsRuntime;
            this.loginService = loginService;
            this.currentUser = currentUser;
        }
        
        
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            if (currentUser.Administrator == null && currentUser.Provider == null)
            {
                var login = new GrpcFileGeneration.Models.Login();
                string administratorAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUserAdministrator");
                string providerAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUserProvider");
                if (!string.IsNullOrEmpty(administratorAsJson))
                {
                    var user = JsonSerializer.Deserialize<Administrator>(administratorAsJson);
                    login.Email = user.Email;
                    login.Password = user.Password;
                    await ValidateUser(login,true);
                }
                else if (!string.IsNullOrEmpty(providerAsJson))
                {
                    var user = JsonSerializer.Deserialize<Provider>(providerAsJson);
                    login.Email = user.Email;
                    login.Password = user.Password;
                    await ValidateUser(login, null);
                }
            }
            else if (currentUser.Administrator != null)
            {
                identity = SetupClaimsForUser(currentUser.Administrator);
            }
            else
            {
                identity = SetupClaimsForUser(currentUser.Provider);
            }
            

            ClaimsPrincipal cachedClaimsPrincipal = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(cachedClaimsPrincipal));
        }

        private ClaimsIdentity SetupClaimsForUser<T>(T user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.GetType().Name)
            };
            ClaimsIdentity identity = new ClaimsIdentity(claims);
            return identity;
        }

        public async Task ValidateUser(GrpcFileGeneration.Models.Login login, bool? isAdministrator)
        {
            if (string.IsNullOrEmpty(login.Email)) throw new Exception("Enter username");
            if (string.IsNullOrEmpty(login.Password)) throw new Exception("Enter password");

            var identity = new ClaimsIdentity();
            try
            {
                string userAsJson ="";
                if (isAdministrator is null or false)
                {
                    var user = await loginService.LoginProvider(login);
                    userAsJson = JsonSerializer.Serialize(user);
                    identity = SetupClaimsForUser(user);
                    cachedUser = user;
                }
                else
                {
                    var user = await loginService.LoginAdministrator(login);
                    userAsJson = JsonSerializer.Serialize(user);
                    identity = SetupClaimsForUser(user);
                    cachedUser = user;
                }
                await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", userAsJson);
                
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