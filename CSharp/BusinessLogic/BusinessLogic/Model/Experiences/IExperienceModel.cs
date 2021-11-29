using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.Experiences
{
    public interface IExperienceModel
    {
        Task<Experience> AddExperienceAsync(Experience experience);
        Task<ExperienceList> GetAllProviderExperiencesAsync(int provider);
        Task<ExperienceList> GetAllWebShopExperiencesAsync();
        Task<Experience> GetExperienceByIdAsync(int id);
        Task DeleteExperienceAsync(int experienceId);
    }
}