using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace WebShop.Data.ProductCategory
{
    public interface IProductCategoryService
    {
        Task<CategoryList> GetAllCategoriesAsync();
    }
}