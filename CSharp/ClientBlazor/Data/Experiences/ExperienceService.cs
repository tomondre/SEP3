using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
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
            uri = "https://localhost:5001/";
        }

        public async Task<Experience> AddExperienceAsync(Experience experience)
        {
            var httpRequest = await GetHttpRequestAsync(HttpMethod.Post, $"{uri}Experiences");
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

        public async Task<ExperienceList> GetAllProviderExperiencesAsync(int? providerId)
        {
            if (providerId == null)
            {
                var protectedBrowserStorageResult = await sessionStorage.GetAsync<User>("currentUser");
                if (protectedBrowserStorageResult.Success)
                {
                    providerId = protectedBrowserStorageResult.Value.Id;
                }
            }
            var httpRequest = await GetHttpRequestAsync(HttpMethod.Get, $"{uri}Providers/{providerId}/Experiences");
            var httpResponseMessage = await client.SendAsync(httpRequest);
            
            CheckException(httpResponseMessage);
            
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<ExperienceList>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task<ExperienceList> GetAllProviderExperiencesByNameAsync(int? providerId, string name)
        {
            var httpRequestMessage = await GetHttpRequestAsync(HttpMethod.Get, $"{uri}Providers/{providerId}/Experiences?name={name}");
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            
            CheckException(httpResponseMessage);

            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var experienceList = JsonSerializer.Deserialize<ExperienceList>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return experienceList;
        }

        public async Task DeleteExperienceAsync(Experience experience)
        {
            var httpRequest = await GetHttpRequestAsync(HttpMethod.Delete, $"{uri}/{experience.Id}");
            var httpResponseMessage = await client.SendAsync(httpRequest);
            
            CheckException(httpResponseMessage);
        }

        private async Task<HttpRequestMessage> GetHttpRequestAsync(HttpMethod method, string uri)
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