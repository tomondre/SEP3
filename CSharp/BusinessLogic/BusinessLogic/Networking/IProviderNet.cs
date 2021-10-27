using System.Collections.Generic;
using ClientServer.Models;

namespace BusinessLogic.Networking
{
    public interface IProviderNet
    {
        public void CreateProvider(Provider provider);
        public IList<Provider> GetAllProviders();
    }
}