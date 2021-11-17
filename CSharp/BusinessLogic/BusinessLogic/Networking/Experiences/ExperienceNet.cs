using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Networking.Experience;

namespace BusinessLogic.Networking.Experiences
{
    public class ExperienceNet : IExperienceNet
    {
        private ExperienceService.ExperienceServiceClient client;

        public ExperienceNet(ExperienceService.ExperienceServiceClient client)
        {
            this.client = client;
        }
        
        public Task<Experience> AddExperienceAsync(Experience experience)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Experience>> GetAllProviderExperiencesAsync(int provider)
        {
            var allProviderExperiences = await client.getAllProviderExperiencesAsync(new ProtobufMessage() {MessageOrObject = provider.ToString()});
            var messageOrObject = allProviderExperiences.MessageOrObject;
            var deserialize = JsonSerializer.Deserialize<IList<Experience>>(messageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public Task<IList<Experience>> GetAllWebShopExperiencesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}