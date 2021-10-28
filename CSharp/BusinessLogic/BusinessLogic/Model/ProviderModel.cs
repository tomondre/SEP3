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
    }
}