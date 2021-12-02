using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking.Providers
{
    public interface IProviderNet
    {
        public Task<User> CreateProviderAsync(Provider provider);
        public Task<IList<Provider>> GetAllProvidersAsync();
        Task<Provider> GetProviderByIdAsync(int id);
        Task<Provider> EditProviderAsync(Provider provider);
        Task DeleteProvider(int id);
        Task<IList<Provider>> GetAllNotApprovedProvidersAsync();
        Task<IList<Provider>> GetAllProvidersByNameAsync(string name);
    }
}