using System.Collections.Generic;
using System.Threading.Tasks;
using ClientServer.Models;

namespace BusinessLogic.Networking
{
    public interface IProviderNet
    {
        public Task CreateProvider(Provider provider);
        public Task<IList<Provider>> GetAllProviders();
    }
}