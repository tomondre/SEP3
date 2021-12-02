using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using WebShop.Services.Experiences;

namespace WebShop.Data.Experiences
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
            var httpResponseMessage = await client.GetAsync($"{uri}experiences?limit=3");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var experienceList = JsonSerializer.Deserialize<ExperienceList>(readAsStringAsync);
            return experienceList;
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