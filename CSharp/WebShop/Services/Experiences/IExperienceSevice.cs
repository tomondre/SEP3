using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace WebShop.Services.Experiences
{
    public interface IExperienceService
    {
        Task<ExperienceList> GetAllExperiencesAsync();
        Task<Experience> GetExperienceById(int id);
        Task<ExperienceList> GetExperiencesByCategoryAsync(int id);
        Task<ExperienceList> GetTopExperiences();
        Task<ExperienceList> GetSortedExperiences(string? name, double price);
    }
}