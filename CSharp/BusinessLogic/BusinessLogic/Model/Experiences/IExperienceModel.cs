using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.Experiences
{
    public interface IExperienceModel
    {
        Task<Experience> AddExperienceAsync(Experience experience);
        Task<IList<Experience>> GetAllProviderExperiencesAsync(int provider);
        Task<IList<Experience>> GetAllWebShopExperiencesAsync();
        Task<Experience> GetExperienceByIdAsync(int id);
        Task<bool> IsInStockAsync(int experienceId ,int quantity);
        Task RemoveStockAsync(int experienceId, int itemQuantity);
        Task DeleteExperienceAsync(int experienceId);
        Task<IList<Experience>> GetAllProviderExperiencesByNameAsync(int id, string name);
        Task<IList<Experience>> GetExperiencesByCategoryAsync(int id);
    }
}