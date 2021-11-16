using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Networking.ProductCategory;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.ProductCategory
{
    public class ProductCategoryModel : IProductCategoryModel
    {
        private IProductCategoryNet network;

        public ProductCategoryModel(IProductCategoryNet network)
        {
            this.network = network;
        }
        
        public async Task<Category> AddProductCategoryAsync(Category category)
        {
            return await network.AddProductCategoryAsync(category);
        }

        public async Task<IList<Category>> GetAllCategoriesAsync()
        {
            return await network.GetAllCategoriesAsync();
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