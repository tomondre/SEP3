using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Experiences
{
    public interface IExperienceService
    {
        Task<Experience> AddExperienceAsync(Experience experience);
        Task<ExperienceList> GetAllProviderExperiencesAsync(int provider);
    }
}