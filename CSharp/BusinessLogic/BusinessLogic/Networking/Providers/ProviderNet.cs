using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Networking.Provider;
using Networking.User;

namespace BusinessLogic.Networking.Providers
{
    public class ProviderNet : IProviderNet
    {
        private ProviderService.ProviderServiceClient client;

        public ProviderNet(ProviderService.ProviderServiceClient client)
        {
            this.client = client;
        }

        public async Task<User> CreateProviderAsync(Provider provider)
        {
            var providerMessage = new ProviderMessage(provider.ToMessage());
            var message = await client.CreateProviderAsync(providerMessage);
            var user = new User(message);
            return user;
        }

        public async Task<IList<Provider>> GetAllProvidersAsync()
        {
            var providersMessage = await client.GetAllProvidersAsync(new ProviderMessage());
            var providers = providersMessage.Providers;
            var providersList = providers.Select(a => new Provider(a)).ToList();
            return providersList;
        }

        public async Task<Provider> GetProviderByIdAsync(int id)
        {
            var userMessage = new UserMessage() {Id = id};
            var providerById = await client.GetProviderByIdAsync(userMessage);
            var provider = new Provider(providerById);
            return provider;
        }

        public async Task<Provider> EditProviderAsync(Provider provider)
        {
            var providerMessage = provider.ToMessage();
            var editProvider = await client.EditProviderAsync(providerMessage);
            var editedProvider = new Provider(editProvider);
            return editedProvider;
        }

        public async Task DeleteProvider(int id)
        {
            var userMessage = new UserMessage() {Id = id};
            await client.RemoveProviderAsync(userMessage);
        }

        public async Task<IList<Provider>> GetAllNotApprovedProvidersAsync()
        {
            var allNotApprovedProviders = await client.GetAllNotApprovedProvidersAsync(new ProviderMessage());
            var providerMessages = allNotApprovedProviders.Providers;
            var providers = providerMessages.Select(a => new Provider(a)).ToList();
            return providers;
        }

        public async Task<IList<Provider>> GetAllProvidersByNameAsync(string name)
        {
            var userMessage = new UserMessage() {Email = name};
            var allByNameAsync = await client.GetAllByNameAsync(userMessage);
            var providerMessages = allByNameAsync.Providers;
            var providers = providerMessages.Select(a => new Provider(a)).ToList();
            return providers;
        }
    }
}