using System.Collections.Generic;
using ClientServer.Models;

namespace ClientServer.RestClient
{
    public interface IProviderNetwork
    {
        void CreateProvider(Provider provider);
        IList<Provider> GetAllProviders();
    }
}