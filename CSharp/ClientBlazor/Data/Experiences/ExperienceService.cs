using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Experiences
{
    public class ExperienceService : IExperienceService
    {
        private HttpClient client;
        private string uri;

        public ExperienceService()
        {
            client = new HttpClient();
            uri = "https://localhost:5001/";
        }

        public async Task<Experience> AddExperienceAsync(Experience experience)
        {
            var experienceAsJson = JsonSerializer.Serialize(experience);
            var stringContent = new StringContent(experienceAsJson, Encoding.UTF8, "application/json");
            var httpResponse = await client.PostAsync($"{uri}Experiences", stringContent);
            CheckException(httpResponse);
            var readAsString = await httpResponse.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<Experience>(readAsString, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task<ExperienceList> GetAllProviderExperiencesAsync(int provider)
        {
            var httpResponseMessage = await client.GetAsync($"{uri}Providers/{provider}/Experiences");
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<ExperienceList>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
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