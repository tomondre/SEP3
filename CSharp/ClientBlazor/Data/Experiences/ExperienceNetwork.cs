using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Experiences
{
    public class ExperienceNetwork : IExperienceNetwork
    {
        private HttpClient client;
        private string uri;

        public ExperienceNetwork()
        {
            client = new HttpClient();
            uri = "https://localhost:5001/Experiences";
        }

        public Task<Experience> AddExperienceAsync(Experience experience)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList> GetAllProviderExperiencesAsync(Provider provider)
        {
            throw new System.NotImplementedException();
        }
    }
}