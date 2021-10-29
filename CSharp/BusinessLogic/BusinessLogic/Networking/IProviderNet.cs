using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking
{
    public interface IProviderNet
    {
        public Task CreateProvider(Provider provider);
        public Task<IList<Provider>> GetAllProviders();
        Task<Provider> GetProviderById(int id);
        Task EditProvider(Provider provider);
    }
}