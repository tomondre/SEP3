using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Networking.Experience;
using Networking.User;

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

        public async Task<IList<Experience>> GetAllProviderExperiencesAsync(int provider)
        {
            var allProviderExperiences = await client.getAllProviderExperiencesAsync(new ProtobufMessage()
                {MessageOrObject = provider.ToString()});
            var messageOrObject = allProviderExperiences.MessageOrObject;
            var deserialize = JsonSerializer.Deserialize<IList<Experience>>(messageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task<IList<Experience>> GetAllWebShopExperiencesAsync()
        {
            var allProviderExperiences = await client.getAllWebShopExperiencesAsync(new ProtobufMessage());
            return JsonSerializer.Deserialize<IList<Experience>>(allProviderExperiences.MessageOrObject,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }

        public async Task<Experience> GetExperienceByIdAsync(int id)
        {
            var experienceByIdAsync =
                await client.getExperienceByIdAsync(new ProtobufMessage() {MessageOrObject = id.ToString()});
            return JsonSerializer.Deserialize<Experience>(experienceByIdAsync.MessageOrObject,
                new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        }

        public async Task<bool> IsInStockAsync(int experienceId, int quantity)
        {
            var isInStockAsync = await client.isInStockAsync(new ProtobufStockRequest()
            {
                Id = experienceId, Quantity = quantity
            });
            bool result = bool.Parse(isInStockAsync.MessageOrObject);
            return result;
        }

        public async Task RemoveStockAsync(int experienceId, int itemQuantity)
        {
            await client.removeStockAsync(new ProtobufStockRequest {Id = experienceId, Quantity = itemQuantity});
        }

        public async Task DeleteExperienceAsync(int experienceId)
        {
            var protobufMessage = new ProtobufMessage() {MessageOrObject = experienceId.ToString()};
            await client.deleteExperienceAsync(protobufMessage);
        }

        public async Task<IList<Experience>> GetExperiencesByCategoryAsync(int id)
        {
            var experienceByCategoryAsync = await client.getExperienceByCategoryAsync(new ProtobufMessage
            {
                MessageOrObject = id.ToString()
            });
            var deserialize = JsonSerializer.Deserialize<IList<Experience>>(experienceByCategoryAsync.MessageOrObject,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return deserialize;
        }

        public async Task<IList<Experience>> GetTopExperiences(int limit)
        {
            var topExperiencesAsync = await client.getTopExperiencesAsync(new ProtobufMessage{MessageOrObject = limit.ToString()});
            var deserialize = JsonSerializer.Deserialize<IList<Experience>>(topExperiencesAsync.MessageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task<IList<Experience>> GetExperiencesByNameAsync(string name)
        {
            var message = await client.getExperiencesByNameAsync(new ProtobufMessage {MessageOrObject = name});
            var deserialize = JsonSerializer.Deserialize<IList<Experience>>(message.MessageOrObject,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return deserialize;
        }

        public async Task<IList<Experience>> GetAllProviderExperiencesByNameAsync(int id, string name)
        {
            var userMessage = new UserMessage() {Id = id, Email = name};
            var allProviderExperiencesByNameAsync = await client.GetAllProviderExperiencesByNameAsync(userMessage);

            var deserialize = JsonSerializer.Deserialize<IList<Experience>>(
                allProviderExperiencesByNameAsync.MessageOrObject, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            return deserialize;
        }
    }
}