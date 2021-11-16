﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Networking.Provider;

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
            await client.createProviderAsync(new ProtobufMessage
            {
                MassageOrObject = serialize(provider)
            });
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
            var providerByIdAsync =
                await client.getProviderByIdAsync(new ProtobufMessage() {MassageOrObject = id.ToString()});
            var massageOrObject = providerByIdAsync.MassageOrObject;
            return JsonSerializer.Deserialize<Provider>(massageOrObject, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        public async Task EditProvider(Provider provider)
        {
            await client.editProviderAsync(new ProtobufMessage {MassageOrObject = serialize(provider)});
        }

        public async Task DeleteProvider(int id)
        {
            await client.removeProviderAsync(new ProtobufMessage {MassageOrObject = id.ToString()});
        }

        public async Task<IList<Provider>> GetAllNotApprovedProviders()
        {
            var allNotApprovedProvidersAsync = await client.getAllNotApprovedProvidersAsync(new ProtobufMessage());
            string objectsAsJson = allNotApprovedProvidersAsync.MassageOrObject;
            return JsonSerializer.Deserialize<IList<Provider>>(objectsAsJson, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }

        private string serialize(Provider provider)
        {
            return JsonSerializer.Serialize(provider, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        }
    }
}