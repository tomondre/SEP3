using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace WebShop.Data.Experiences
{
    public class ExperienceService : IExperienceService
    {
        private HttpClient client;
        private string uri;

        public ExperienceService()
        {
            client = new HttpClient();
            uri = "https://localhost:5001/Experiences";
        }

        public async Task<ExperienceList> GetAllExperiences()
        {
            var httpResponseMessage = await client.GetAsync(uri);
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
            var httpResponseMessage = await client.GetAsync($"{uri}/{id}");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<Experience>(readAsStringAsync,
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
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