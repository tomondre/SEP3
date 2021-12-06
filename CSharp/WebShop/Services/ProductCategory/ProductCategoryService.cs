using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Services.ProductCategory
{
    public class ProductCategoryService : IProductCategoryService
    {
        private HttpClient client;
        private string uri;

        public ProductCategoryService(HttpClient client)
        {
            this.client = client;
            uri = "https://localhost:5001/ProductCategory";
        }

        public async Task<Page<CategoryList>> GetAllCategoriesAsync()
        {
            var httpResponseMessage = await client.GetAsync($"{uri}?page=0");
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var categories = JsonSerializer.Deserialize<Page<CategoryList>>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return categories;
        }

        private void CheckException(HttpResponseMessage task)
        {
            if (!task.IsSuccessStatusCode)
            {
                throw new Exception($"Code: {task.StatusCode}, {task.ReasonPhrase} ");
            }
        }
    }
}