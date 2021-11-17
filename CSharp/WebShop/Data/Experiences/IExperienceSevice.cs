using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace WebShop.Data.Experiences
{
    public interface IExperienceService
    {
        Task<ExperienceList> GetAllExperiences();
    }
}