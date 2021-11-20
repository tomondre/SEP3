using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Networking.ProductCategory;
using GrpcFileGeneration.Models;
using Microsoft.Extensions.Caching.Memory;

namespace BusinessLogic.Model.ProductCategory
{
    public class ProductCategoryModel : IProductCategoryModel
    {
        private IProductCategoryNet network;
        private IMemoryCache memoryCache;

        public ProductCategoryModel(IProductCategoryNet network, IMemoryCache memoryCache)
        {
            this.network = network;
            this.memoryCache = memoryCache;
        }
        
        public async Task<Category> AddProductCategoryAsync(Category category)
        {
            return await network.AddProductCategoryAsync(category);
        }

        public async Task<IList<Category>> GetAllCategoriesAsync()
        {
            IList<Category> result;
            bool AlreadyExists = memoryCache.TryGetValue("CachedExperiences", out result);
            if (!AlreadyExists)
            {
                result = await network.GetAllCategoriesAsync();
                var slidingExpiration = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1));
                memoryCache.Set("CachedExperiences", result, slidingExpiration);
            }

            return result;
        }

        public async Task<Category> EditProductCategoryAsync(Category category)
        {
            return await network.EditProductCategoryAsync(category);
        }

        public async Task DeleteProductCategoryAsync(int id)
        {
            await network.DeleteProductCategoryAsync(id);
        }
    }
}