using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking.Experiences
{
    public interface IExperienceNet
    {
        Task<Experience> AddExperienceAsync(Experience experience);
        Task<IList<Experience>> GetAllProviderExperiencesAsync(Provider provider);
        Task<IList<Experience>> GetAllWebShopExperiencesAsync();
    }
}