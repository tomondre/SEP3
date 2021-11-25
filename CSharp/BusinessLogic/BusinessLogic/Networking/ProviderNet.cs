using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Networking.Address;
using Networking.Provider;
using Networking.User;

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
            var providerMessage = new ProviderMessage(provider.ToMessage());
            var message = client.CreateProvider(providerMessage);
            //TODO finish implementation
        }

        public async Task<IList<Provider>> GetAllProviders()
        {
            // IList<Provider> result;
            // var allProvidersAsync = await client.GetAllProvidersAsync(new ProtobufMessage());
            // var massageOrObject = allProvidersAsync.MassageOrObject;
            // result = JsonSerializer.Deserialize<IList<Provider>>(massageOrObject, new JsonSerializerOptions()
            // {
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            // });
            // return result;
            return null;
        }

        public async Task<Provider> GetProviderById(int id)
        {
            // var providerByIdAsync =
            //     await client.getProviderByIdAsync(new ProtobufMessage() {MassageOrObject = id.ToString()});
            // var massageOrObject = providerByIdAsync.MassageOrObject;
            // return JsonSerializer.Deserialize<Provider>(massageOrObject, new JsonSerializerOptions
            // {
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            // });
            return null;
        }

        public async Task EditProvider(Provider provider)
        {
            // await client.editProviderAsync(new ProtobufMessage {MassageOrObject = serialize(provider)});
        }

        public async Task DeleteProvider(int id)
        {
            // await client.removeProviderAsync(new ProtobufMessage {MassageOrObject = id.ToString()});
        }

        public async Task<IList<Provider>> GetAllNotApprovedProviders()
        {
            // var allNotApprovedProvidersAsync = await client.getAllNotApprovedProvidersAsync(new ProtobufMessage());
            // string objectsAsJson = allNotApprovedProvidersAsync.MassageOrObject;
            // return JsonSerializer.Deserialize<IList<Provider>>(objectsAsJson, new JsonSerializerOptions()
            // {
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            // });
            return null;
        }
        
        private string serialize(Provider provider)
        {
            // return JsonSerializer.Serialize(provider, new JsonSerializerOptions()
            // {
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            // });
            return null;
        }
    }
}