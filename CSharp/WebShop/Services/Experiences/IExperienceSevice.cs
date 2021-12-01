using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace WebShop.Services.Experiences
{
    public interface IExperienceService
    {
        Task<ExperienceList> GetAllExperiencesAsync();
        Task<Experience> GetExperienceById(int id);
        Task<ExperienceList> GetExperiencesByCategoryAsync(string category);
    }
}