using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Networking.ProductCategory
{
    public interface IProductCategoryNet
    {
        Task<Category> AddProductCategoryAsync(Category category);
        Task<IList<Category>> GetAllCategoriesAsync();
        Task<Category> EditProductCategoryAsync(Category category);
        Task DeleteProductCategoryAsync(int id);
    }
}