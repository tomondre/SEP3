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

        public Task<IList<Experience>> GetAllProviderExperiencesAsync(Provider provider)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<Experience>> GetAllWebShopExperiencesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}