using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data
{
    public interface IProviderService
    {
        public Task CreateProvider(Provider provider);
        public Task<ProviderList> GetAllProviders();
        Task<Provider> GetProviderById(int id);
        Task EditProvider(Provider provider);
        Task DeleteProvider(int id);
    }
}