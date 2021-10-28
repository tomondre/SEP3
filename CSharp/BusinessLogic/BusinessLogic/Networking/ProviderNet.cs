using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientServer.Models;
using Grpc.Net.Client;

namespace BusinessLogic.Networking
{
    public class ProviderNet : IProviderNet
    {
        private ProviderService.ProviderServiceClient client;
        public ProviderNet(ProviderService.ProviderServiceClient client)
        {
            this.client = client;
        }

        public async Task CreateProvider(Provider provider)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Provider>> GetAllProviders()
        {
            Console.WriteLine(client);
            var allProvidersAsync = await client.getAllProvidersAsync(new Request());
            Console.WriteLine(allProvidersAsync.Value.Count);
            throw new NotImplementedException();
            return null;
        }
    }
}