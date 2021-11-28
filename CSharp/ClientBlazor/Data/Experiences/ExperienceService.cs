using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace ClientBlazor.Data.Experiences
{
    public class ExperienceService : IExperienceService
    {
        private readonly ProtectedSessionStorage sessionStorage;
        private HttpClient client;
        private string uri;

        public ExperienceService(ProtectedSessionStorage sessionStorage)
        {
            this.sessionStorage = sessionStorage;
            client = new HttpClient();
            uri = "https://localhost:5001/Experiences";
        }

        public async Task<Experience> AddExperienceAsync(Experience experience)
        {
            var httpRequest = await GetHttpRequest(HttpMethod.Post, uri);
            var experienceAsJson = JsonSerializer.Serialize(experience);
            var stringContent = new StringContent(experienceAsJson, Encoding.UTF8, "application/json");
            httpRequest.Content = stringContent;
            var httpResponse = await client.SendAsync(httpRequest);
            
            CheckException(httpResponse);

            var readAsString = await httpResponse.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<Experience>(readAsString, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task<IList<Experience>> GetAllProviderExperiencesAsync(int provider)
        {
            var httpRequest = await GetHttpRequest(HttpMethod.Get, $"{uri}/{provider}");
            var httpResponseMessage = await client.SendAsync(httpRequest);
            
            CheckException(httpResponseMessage);
            
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<IList<Experience>>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }
        
        private async Task<HttpRequestMessage> GetHttpRequest(HttpMethod method, string uri)
        {
            var httpRequestMessage = new HttpRequestMessage(method, uri);
            var token = await sessionStorage.GetAsync<string>("token");
            if (token.Success)
            {
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            }
            //TODO add exception
            return httpRequestMessage;
        }
        
        private void CheckException(HttpResponseMessage task)
        {
            if (!task.IsSuccessStatusCode)
            {
                throw new Exception($"Code: {task.StatusCode}, {task.ReasonPhrase} ");
            }
        }
    }
}