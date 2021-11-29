using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking.Experiences
{
    public interface IExperienceNet
    {
        Task<Experience> AddExperienceAsync(Experience experience);
        Task<ExperienceList> GetAllProviderExperiencesAsync(int provider);
        Task<ExperienceList> GetAllWebShopExperiencesAsync();
        Task<Experience> GetExperienceByIdAsync(int id);
        Task<bool> IsInStockAsync(int experienceId,int quantity );
        Task DeleteExperienceAsync(int experienceId);
    }
}