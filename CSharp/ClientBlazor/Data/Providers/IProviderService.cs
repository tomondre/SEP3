using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.Providers
{
    public interface IProviderService
    {
        public Task CreateProvider(Provider provider);
        public Task<Page<ProviderList>> GetAllProviders(int page);
        Task<Provider> GetProviderById(int id);
        Task<Provider> EditProvider(Provider provider);
        Task DeleteProvider(Provider provider);
        Task<Page<ProviderList>> GetAllNotApprovedProvidersAsync(int page);
        Task<Page<ProviderList>> GetAllProvidersByNameAsync(string name, int page);
    }
}