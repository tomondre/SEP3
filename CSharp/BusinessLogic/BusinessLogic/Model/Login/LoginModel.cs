using System;
using System.Threading.Tasks;
using BusinessLogic.Networking.Login;
using GrpcFileGeneration.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLogic.Model.Login
{
    public class LoginModel :ILoginModel
    {
        private ILoginNet net;
        private readonly string key;

        public LoginModel(ILoginNet net, string key)
        {
            this.net = net;
            this.key = key;
        }

        public async Task<Customer> AuthenticateCustomerAsync(string username, string password)
        {
            var customerLoginAsync = await net.GetCustomerLoginAsync(username);
            if (customerLoginAsync == null)
            {
                return null;
            }

            customerLoginAsync.Token = WriteToken(username);

            return customerLoginAsync;
        }
        
        public async Task<Provider> AuthenticateProviderAsync(string username, string password)
        {
            var providerLoginAsync = await net.GetProviderLoginAsync(username);
            if (providerLoginAsync == null)
            {
                return null;
            }

            providerLoginAsync.Token = WriteToken(username);
            return providerLoginAsync;
        }

        public async Task<Administrator> AuthenticateAdministratorAsync(string username, string password)
        {
            var addAdministratorLoginAsync = await net.AddAdministratorLoginAsync(username);
            if (addAdministratorLoginAsync == null)
            {
                return null;
            }

            addAdministratorLoginAsync.Token = WriteToken(username);
            return addAdministratorLoginAsync;
        }
        
        private string WriteToken(string username)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var writeToken = jwtSecurityTokenHandler.WriteToken(securityToken);
            return writeToken;
        }

    }
}