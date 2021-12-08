using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Services.Experiences
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

        public async Task<ExperienceList> GetAllExperiencesAsync()
        {
            var httpResponseMessage = await client.GetAsync($"{uri}experiences");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<ExperienceList>(readAsStringAsync,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return deserialize;
        }

        public async Task<Experience> GetExperienceById(int id)
        {
            var httpResponseMessage = await client.GetAsync($"{uri}experiences/{id}");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<Experience>(readAsStringAsync,
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return deserialize;
        }

        public async Task<ExperienceList> GetExperiencesByCategoryAsync(int id)
        {
            var httpResponseMessage = await client.GetAsync($"{uri}categories/{id}/experiences");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ExperienceList>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
        }

        public async Task<ExperienceList> GetTopExperiences()
        {
            var httpResponseMessage = await client.GetAsync($"{uri}experiences?top=true");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var experienceList = JsonSerializer.Deserialize<ExperienceList>(readAsStringAsync, new JsonSerializerOptions(){PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return experienceList;
        }

        public async Task<ExperienceList> GetSortedExperiences(string? name, double price)
        {
            var httpResponseMessage = await client.GetAsync($"{uri}experiences/?name={name}&price={price}");
            
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ExperienceList>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
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