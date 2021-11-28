﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Networking.Providers;
using GrpcFileGeneration.Models;
using GrpcFileGeneration.Services;

namespace BusinessLogic.Model.Providers
{
    public class ProviderModel : IProviderModel
    {
        IProviderNet network;
        private IValidator validator;
        
        public ProviderModel(IProviderNet network, IValidator validator)
        {
            this.network = network;
            this.validator = validator;
        }

        public Task<User> CreateProvider(Provider provider)
        {
            //TODO validator redundant as we have the validation constrains in the model classes
            // if (!validator.isValidCvr(provider.Cvr))
            //     throw new Exception("The CVR must be between 10000000 and 99999999.");
            // if(!validator.isValidEmail(provider.Email))
            //     throw new Exception("The email address is not valid.");
            // if(!validator.isValidPassword(provider.Password))
            //     throw new Exception("The password must be between 8 (included) and 14 (included) characters,  " +
            // " contain at least one number," +
            //     " contain at least one upper case character and" +
            //     " contain at least one lower case character");
            // if (!validator.isValidPostCode(provider.Address.PostCode))
            // {
            //     throw new Exception("The post code must be between 1000 and 9999");
            // }
            return network.CreateProviderAsync(provider);
        }

        public Task<IList<Provider>> GetAllProviders()
        {
            return network.GetAllProvidersAsync();
        }

        public Task<Provider> GetProviderById(int id)
        {
            return network.GetProviderByIdAsync(id);
        }

        public Task EditProvider(Provider provider)
        {
            return network.EditProviderAsync(provider);
        }

        public Task DeleteProvider(int id)
        {
            return network.DeleteProvider(id);
        }

        public Task<IList<Provider>> GetAllNotApprovedProviders()
        {
            return network.GetAllNotApprovedProvidersAsync();
        }
    }
}