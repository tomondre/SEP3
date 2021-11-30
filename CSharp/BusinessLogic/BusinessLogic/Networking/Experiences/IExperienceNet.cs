using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking.Experiences
{
    public interface IExperienceNet
    {
        Task<Experience> AddExperienceAsync(Experience experience);
        Task<IList<Experience>> GetAllProviderExperiencesAsync(int provider);
        Task<IList<Experience>> GetAllWebShopExperiencesAsync();
        Task<Experience> GetExperienceByIdAsync(int id);
        Task<bool> IsInStockAsync(int experienceId,int quantity );
        Task RemoveStockAsync(int experienceId, int itemQuantity);
        Task DeleteExperienceAsync(int experienceId);
    }
}