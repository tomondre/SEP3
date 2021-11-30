using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Networking.Experiences;
using GrpcFileGeneration.Models;
using Microsoft.Extensions.Caching.Memory;

namespace BusinessLogic.Model.Experiences
{
    public class ExperienceModel : IExperienceModel
    {
        private IExperienceNet network;
        private IMemoryCache memoryCache;

        public ExperienceModel(IExperienceNet network, IMemoryCache memoryCache)
        {
            this.network = network;
            this.memoryCache = memoryCache;
        }
        
        public async Task<Experience> AddExperienceAsync(Experience experience)
        {
            memoryCache.Remove("CachedExperiences");
            return await network.AddExperienceAsync(experience);
        }

        public async Task<IList<Experience>> GetAllProviderExperiencesAsync(int provider)
        {
            return await network.GetAllProviderExperiencesAsync(provider);
        }

        public async Task<IList<Experience>> GetAllWebShopExperiencesAsync()
        {
            IList<Experience> result;
            bool AlreadyExists = memoryCache.TryGetValue("CachedExperiences", out result);
            if (!AlreadyExists)
            { 
                result = await network.GetAllWebShopExperiencesAsync();
                var slidingExpiration = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1));
                memoryCache.Set("CachedExperiences", result, slidingExpiration);
            }

            return result;
        }

        public async Task<Experience> GetExperienceByIdAsync(int id)
        {
            return await network.GetExperienceByIdAsync(id);
        }

        public Task<bool> IsInStockAsync(int experienceId, int quantity)
        {
            return network.IsInStockAsync(experienceId, quantity);
        }

        public async Task RemoveStockAsync(int experienceId, int itemQuantity)
        {
            await network.RemoveStockAsync(experienceId, itemQuantity);
        }

        public async Task DeleteExperienceAsync(int experienceId)
        {
            await network.DeleteExperienceAsync(experienceId);
        }
    }
}