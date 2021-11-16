using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Networking.Experiences;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.Experiences
{
    public class ExperienceModel : IExperienceModel
    {
        private IExperienceNet network;

        public ExperienceModel(IExperienceNet network)
        {
            this.network = network;
        }
        
        public async Task<Experience> AddExperienceAsync(GrpcFileGeneration.Models.Experience experience)
        {
            return await network.AddExperienceAsync(experience);
        }

        public async Task<IList<Experience>> GetAllProviderExperiencesAsync(int provider)
        {
            return await network.GetAllProviderExperiencesAsync(provider);
        }

        public async Task<IList<Experience>> GetAllWebShopExperiencesAsync()
        {
            return await network.GetAllWebShopExperiencesAsync();
        }
    }
}