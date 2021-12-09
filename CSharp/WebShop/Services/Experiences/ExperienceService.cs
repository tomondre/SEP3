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

        public async Task<Page<ExperienceList>> GetAllExperiencesAsync(int page)
        {
            var httpResponseMessage = await client.GetAsync($"{uri}experiences?page={page}");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<Page<ExperienceList>>(readAsStringAsync,
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

        public async Task<Page<ExperienceList>> GetExperiencesByCategoryAsync(int id, int page)
        {
            var httpResponseMessage = await client.GetAsync($"{uri}categories/{id}/experiences?page={page}");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Page<ExperienceList>>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
        }

        public async Task<ExperienceList> GetTopExperiences()
        {
            var httpResponseMessage = await client.GetAsync($"{uri}experiences?top=true");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var experienceList = JsonSerializer.Deserialize<Page<ExperienceList>>(readAsStringAsync, new JsonSerializerOptions(){PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return experienceList.Content;
        }

        public async Task<Page<ExperienceList>> GetSortedExperiences(string name, double price, int page)
        {
            var httpResponseMessage = await client.GetAsync($"{uri}experiences/?name={name}&price={price}&page={page}");
            
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Page<ExperienceList>>(readAsStringAsync, new JsonSerializerOptions()
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