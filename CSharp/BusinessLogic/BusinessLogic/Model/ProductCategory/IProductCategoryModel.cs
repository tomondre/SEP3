using System.Collections.Generic;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace BusinessLogic.Model.ProductCategory
{
    public interface IProductCategoryModel
    {
        Task<Category> AddProductCategoryAsync(Category category);
        Task<IList<Category>> GetAllCategoriesAsync();
        Task<Category> EditProductCategoryAsync(Category category);
        Task DeleteProductCategoryAsync(int id);
    }
}