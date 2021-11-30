using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using ProviderObject = GrpcFileGeneration.Models.Provider;

namespace ClientBlazor.Data.Providers
{
    public interface IProviderService
    {
        public Task CreateProvider(ProviderObject provider);
        public Task<ProviderList> GetAllProviders();
        Task<ProviderObject> GetProviderById(int id);
        Task<Provider> EditProvider(Provider provider);
        Task DeleteProvider(ProviderObject provider);
        Task<ProviderList> GetAllNotApprovedProvidersAsync();
    }
}