﻿using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.Providers
{
    public interface IProviderModel
    {
        public Task<User> CreateProvider(Provider provider);
        public Task<IList<Provider>> GetAllProviders();
        Task<Provider> GetProviderById(int id);
        Task EditProvider(Provider provider);
        Task DeleteProvider(int id);
        Task<IList<Provider>> GetAllNotApprovedProviders();
        Task<IList<Provider>> GetAllProvidersByNameAsync(string name);

    }
}