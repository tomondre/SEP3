using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.Providers
{
    public interface IProviderModel
    {
        public Task<User> CreateProvider(Provider provider);
        public Task<IList<Provider>> GetAllProviders();
        Task<Provider> GetProviderByIdAsync(int id);
        Task<Provider> EditProviderAsync(Provider provider);
        Task DeleteProvider(int id);
        Task<IList<Provider>> GetAllNotApprovedProviders();
    }
}