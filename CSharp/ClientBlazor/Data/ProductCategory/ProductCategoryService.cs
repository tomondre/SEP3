using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;

namespace ClientBlazor.Data.ProductCategory
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
        
        public async Task<Category> AddProductCategoryAsync(Category category)
        {
            var categoryAsJson = JsonSerializer.Serialize(category);
            var stringContent = new StringContent(categoryAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PostAsync(uri, stringContent);
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<Category>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task<CategoryList> GetAllCategoriesAsync()
        {
            var httpResponseMessage = await client.GetAsync(uri);
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var categories = JsonSerializer.Deserialize<CategoryList>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return categories;
        }

        public async Task<Category> EditProductCategoryAsync(Category category)
        {
            var categoryAsJson = JsonSerializer.Serialize(category);
            var stringContent = new StringContent(categoryAsJson, Encoding.UTF8, "application/json");
            var httpResponseMessage = await client.PutAsync(uri, stringContent);
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<Category>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            return deserialize;
        }

        public async Task DeleteProductCategoryAsync(int id)
        {
            var httpResponseMessage = await client.DeleteAsync(uri + $"/{id}");
            CheckException(httpResponseMessage);
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