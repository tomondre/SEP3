using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.ProductCategory
{
    public interface IProductCategoryService
    {
        Task<Category> AddProductCategoryAsync(Category category);
        Task<Page<CategoryList>> GetAllCategoriesAsync(int page);
        Task<Category> EditProductCategoryAsync(Category category);
    }
}