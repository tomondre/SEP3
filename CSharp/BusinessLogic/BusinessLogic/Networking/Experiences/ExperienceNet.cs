using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Networking.Experience;
using Networking.Request;
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
            var protobufMessage = await client.addExperienceAsync(experience.ToMessage());
            return new Experience(protobufMessage);
        }

        public async Task<IList<Experience>> GetAllProviderExperiencesAsync(int provider)
        {
            var allProviderExperiencesAsync = await client.getAllProviderExperiencesAsync(new RequestMessage {Id = provider});
            return ExperienceListMessageToList(allProviderExperiencesAsync);
        }

        public async Task<IList<Experience>> GetAllWebShopExperiencesAsync()
        {
            
            var allWebShopExperiencesAsync = await client.getAllWebShopExperiencesAsync(new RequestMessage());
            return ExperienceListMessageToList(allWebShopExperiencesAsync);
        }

        public async Task<Experience> GetExperienceByIdAsync(int id)
        {
            var experienceByIdAsync = await client.getExperienceByIdAsync(new RequestMessage {Id = id});
            return new Experience(experienceByIdAsync);
        }

        public async Task<bool> IsInStockAsync(int experienceId, int quantity)
        {
            var isInStockAsync = await client.isInStockAsync(new RequestMessage {Id = experienceId, Quantity = quantity});
            return isInStockAsync.Response;
        }

        public async Task RemoveStockAsync(int experienceId, int itemQuantity)
        {
            await client.removeStockAsync(new RequestMessage() {Id = experienceId, Quantity = itemQuantity});
        }

        public async Task DeleteExperienceAsync(int experienceId)
        {
            await client.deleteExperienceAsync(new RequestMessage {Id = experienceId});
        }

        public async Task<IList<Experience>> GetExperiencesByCategoryAsync(int id)
        {
            var experienceByCategoryAsync = await client.getExperienceByCategoryAsync(new RequestMessage() {Id = id});
            return ExperienceListMessageToList(experienceByCategoryAsync);
        }

        public async Task<IList<Experience>> GetTopExperiences()
        {
            var experienceListMessage = await client.getTopExperiencesAsync(new RequestMessage());
            return ExperienceListMessageToList(experienceListMessage);
        }

        private List<Experience> ExperienceListMessageToList(ExperienceListMessage list)
        {
            var result = new List<Experience>();
            foreach (var e in list.Experiences)
            {
                result.Add(new Experience(e));
            }

            return result;
        }

        public async Task<IList<Experience>> GetExperiencesByNameAsync(string name)
        {
            var message = await client.getExperiencesByNameAsync(new RequestMessage(){Name = name});
            return ExperienceListMessageToList(message);
        }

        public async Task<IList<Experience>> GetAllProviderExperiencesByNameAsync(int id, string name)
        {
            var allProviderExperiencesByNameAsync = await client.GetAllProviderExperiencesByNameAsync(new RequestMessage {Id = id, Name = name});
            return ExperienceListMessageToList(allProviderExperiencesByNameAsync);
        }
    }
}