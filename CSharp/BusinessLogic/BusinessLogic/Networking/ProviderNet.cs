using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            await client.createProviderAsync(ModelProviderToProtobufProvider(provider));
        }

        public async Task<IList<Provider>> GetAllProviders()
        {
            Console.WriteLine(client);
            IList<Provider> result = new List<Provider>();
            var providers = (await client.getAllProvidersAsync(new ProtobufRequest())).Value;
            foreach (var provider in providers)
            {
                result.Add(ProtobufProviderToModelProvider(provider));
            }

            return result;
        }

        private ProtobufProvider ModelProviderToProtobufProvider(Provider provider)
        {
            return new ProtobufProvider()
            {
                CompanyName = provider.CompanyName,
                Cvr = provider.Cvr,
                Description = provider.Description,
                PhoneNumber = provider.PhoneNumber,
                Address = new ProtobufAddress()
                {
                    City = provider.Address.City,
                    Street = provider.Address.Street,
                    PostCode = provider.Address.PostCode,
                    StreetNumber = provider.Address.StreetNumber
                }
            };
        }

        private Provider ProtobufProviderToModelProvider(ProtobufProvider provider)
        {
            return new Provider()
            {
                    CompanyName = provider.CompanyName,
                    Cvr = provider.Cvr,
                    Description = provider.Description,
                    PhoneNumber = provider.PhoneNumber,
                    Address = new Address()
                    {
                        City = provider.Address.City,
                        Street = provider.Address.Street,
                        PostCode = provider.Address.PostCode,
                        StreetNumber = provider.Address.StreetNumber
                    }
            };
        }
    }
}