using System.Collections.Generic;
using ClientServer.Models;

namespace BusinessLogic.Model
{
    public interface IProviderModel
    {
        public void CreateProvider(Provider provider);
        public IList<Provider> GetAllProviders();
    }
}