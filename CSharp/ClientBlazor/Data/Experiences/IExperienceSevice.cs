using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Experiences
{
    public interface IExperienceService
    {
        Task<Experience> AddExperienceAsync(Experience experience);
        Task<ExperienceList> GetAllProviderExperiencesAsync(int? providerId);
        Task<ExperienceList> GetAllProviderExperiencesByNameAsync(int? providerId, string name);

        Task DeleteExperienceAsync(Experience experience);
        Task<Experience> GetExperienceByIdAsync(int id);
        Task<Experience>  EditExperienceAsync(Experience experience);
    }
}