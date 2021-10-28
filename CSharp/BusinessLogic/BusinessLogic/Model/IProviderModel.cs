using System.Collections.Generic;
using System.Threading.Tasks;
using ClientServer.Models;

namespace BusinessLogic.Model
{
    public interface IProviderModel
    {
        public Task CreateProvider(Provider provider);
        public Task<IList<Provider>> GetAllProviders();
    }
}