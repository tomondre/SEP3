using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Networking;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model
{
    public class ProviderModel : IProviderModel
    {
        IProviderNet network;
        public ProviderModel(IProviderNet network)
        {
            this.network = network;
        }

        public Task CreateProvider(Provider provider)
        {
           return network.CreateProvider(provider);
        }

        public Task<IList<Provider>> GetAllProviders()
        {
            return network.GetAllProviders();
        }

        public Task<Provider> GetProviderById(int id)
        {
            return network.GetProviderById(id);
        }

        public Task EditProvider(Provider provider)
        {
            return network.EditProvider(provider);
        }

        public Task DeleteProvider(int id)
        {
            return network.DeleteProvider(id);
        }

        public Task<IList<Provider>> GetAllNotApprovedProviders()
        {
            return network.GetAllNotApprovedProviders();
        }
    }
}