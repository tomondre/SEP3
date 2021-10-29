using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Model
{
    public interface IProviderModel
    {
        public Task CreateProvider(Provider provider);
        public Task<IList<Provider>> GetAllProviders();
        Task<Provider> GetProviderById(int id);
        Task EditProvider(Provider provider);
    }
}