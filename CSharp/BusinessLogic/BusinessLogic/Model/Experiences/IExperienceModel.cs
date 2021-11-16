using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.Experiences
{
    public interface IExperienceModel
    {
        Task<Experience> AddExperienceAsync(Experience experience);
        Task<IList<Experience>> GetAllProviderExperiencesAsync(Provider provider);
        Task<IList<Experience>> GetAllWebShopExperiencesAsync();
    }
}