using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace WebShop.Services.Experiences
{
    public interface IExperienceService
    {
        Task<ExperienceList> GetAllExperiences();
        Task<Experience> GetExperienceById(int id);
    }
}