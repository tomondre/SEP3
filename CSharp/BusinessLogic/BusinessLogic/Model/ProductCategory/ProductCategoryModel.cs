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
            memoryCache.Remove("CachedCategories");
            return await network.AddProductCategoryAsync(category);
        }

        public async Task<IList<Category>> GetAllCategoriesAsync()
        {
            IList<Category> result;
            bool AlreadyExists = memoryCache.TryGetValue("CachedCategories", out result);
            if (!AlreadyExists)
            {
                result = await network.GetAllCategoriesAsync();
                var slidingExpiration = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1));
                memoryCache.Set("CachedCategories", result, slidingExpiration);
            }

            return result;
        }

        public async Task<Category> EditProductCategoryAsync(Category category)
        {
            memoryCache.Remove("CachedCategories");
            return await network.EditProductCategoryAsync(category);
        }

        public async Task DeleteProductCategoryAsync(int id)
        {
            memoryCache.Remove("CachedCategories");
            await network.DeleteProductCategoryAsync(id);
        }
    }
}