using System.Collections;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Experiences
{
    public interface IExperienceNetwork
    {
        Task<Experience> AddExperienceAsync(Experience experience);
        Task<IList<Exeperience>> GetAllProviderExperiencesAsync(Provider provider);
    }
}