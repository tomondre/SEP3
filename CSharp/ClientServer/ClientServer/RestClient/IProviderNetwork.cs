using System.Collections.Generic;
using GrpcFileGeneration.Models;

namespace ClientServer.RestClient
{
    public interface IProviderNetwork
    {
        void CreateProvider(Provider provider);
        IList<Provider> GetAllProviders();
    }
}