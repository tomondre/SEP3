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
            var protobufMessage = await client.addExperienceAsync(new ProtobufMessage() {MessageOrObject = serialize});
            return JsonSerializer.Deserialize<Experience>(protobufMessage.MessageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        public async Task<ExperienceList> GetAllProviderExperiencesAsync(int provider)
        {
            var allProviderExperiences = await client.getAllProviderExperiencesAsync(new ProtobufMessage()
                {MessageOrObject = provider.ToString()});
            var messageOrObject = allProviderExperiences.MessageOrObject;
            var deserialize = JsonSerializer.Deserialize<ExperienceList>(messageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task<ExperienceList> GetAllWebShopExperiencesAsync()
        {
            var allProviderExperiences = await client.getAllWebShopExperiencesAsync(new ProtobufMessage());
            return JsonSerializer.Deserialize<ExperienceList>(allProviderExperiences.MessageOrObject,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }

        public async Task<Experience> GetExperienceByIdAsync(int id)
        {
            var experienceByIdAsync = await client.getExperienceByIdAsync(new ProtobufMessage() {MessageOrObject = id.ToString()});
            return JsonSerializer.Deserialize<Experience>(experienceByIdAsync.MessageOrObject, new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }

        public async Task<bool> IsInStockAsync(int experienceId, int quantity)
        {
            var isInStockAsync = await client.isInStockAsync(new ProtobufStockRequest()
            {
                Id = experienceId, Quantity = quantity
            });
            bool result =  bool.Parse(isInStockAsync.MessageOrObject);
            return result;
        }

        public async Task RemoveStockAsync(int experienceId, int itemQuantity)
        {
            await client.removeStockAsync(new ProtobufStockRequest{Id = experienceId, Quantity = itemQuantity});
        }
    }
}