using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking.Experiences
{
    public class ExperienceNet : IExperienceNet
    {
        private ExperienceSer
        public Task<Experience> AddExperienceAsync(Experience experience)
        {
            throw new System.NotImplementedException();
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