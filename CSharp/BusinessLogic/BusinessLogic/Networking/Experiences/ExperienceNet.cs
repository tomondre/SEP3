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

        public async Task<Experience> AddExperienceAsync(Experience experience)
        {
            var serialize = JsonSerializer.Serialize(experience);
            var protobufMessage = await client.addExperienceAsync(new ProtobufMessage(){MessageOrObject = serialize});
            return JsonSerializer.Deserialize<Experience>(protobufMessage.MessageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
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