using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Com.Example.Dataserver.Networking;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking
{
    public class ProviderNet : IProviderNet
    {
        private ProtobufProviderService.ProtobufProviderServiceClient client;

        public ProviderNet(ProtobufProviderService.ProtobufProviderServiceClient client)
        {
            this.client = client;
        }

        public async Task CreateProvider(Provider provider)
        {
            var serialize = JsonSerializer.Serialize(provider);
            await client.createProviderAsync(new ProtobufMessage {MassageOrObject = serialize});
        }

        public async Task<IList<Provider>> GetAllProviders()
        {
            IList<Provider> result;
            var allProvidersAsync = await client.getAllProvidersAsync(new ProtobufMessage());
            var massageOrObject = allProvidersAsync.MassageOrObject;
            result = JsonSerializer.Deserialize<IList<Provider>>(massageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return result;
        }

        public async Task<Provider> GetProviderById(int id)
        {
            var providerByIdAsync = await client.getProviderByIdAsync(new ProtobufMessage(){MassageOrObject = id.ToString()});
            var massageOrObject = providerByIdAsync.MassageOrObject;
            return JsonSerializer.Deserialize<Provider>(massageOrObject, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        public async Task EditProvider(Provider provider)
        {
            var serialize = JsonSerializer.Serialize(provider);
            await client.editProviderAsync(new ProtobufMessage {MassageOrObject = serialize});
        }

        public async Task DeleteProvider(int id)
        {
            await client.removeProviderAsync(new ProtobufMessage {MassageOrObject = id.ToString()});
        }
    }
}