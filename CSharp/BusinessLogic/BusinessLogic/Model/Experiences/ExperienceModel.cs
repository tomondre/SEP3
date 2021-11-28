using System;
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

        public async Task<ExperienceList> GetAllProviderExperiencesAsync(int provider)
        {
            return await network.GetAllProviderExperiencesAsync(provider);
        }

        public async Task<ExperienceList> GetAllWebShopExperiencesAsync()
        {
            ExperienceList result;
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
    }
}