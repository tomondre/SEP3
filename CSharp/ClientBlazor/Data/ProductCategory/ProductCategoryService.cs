using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace ClientBlazor.Data.ProductCategory
{
    public class ProductCategoryService : IProductCategoryService
    {
        private HttpClient client;
        private readonly ProtectedSessionStorage sessionStorage;
        private string uri;

        public ProductCategoryService(HttpClient client, ProtectedSessionStorage sessionStorage)
        {
            this.client = client;
            this.sessionStorage = sessionStorage;
            uri = "https://localhost:5001/ProductCategory";
        }
        
        public async Task<Category> AddProductCategoryAsync(Category category)
        {
            var httMethod = await GetHttMethod(HttpMethod.Post, uri);
            var categoryAsJson = JsonSerializer.Serialize(category);
            var stringContent = new StringContent(categoryAsJson, Encoding.UTF8, "application/json");
            httMethod.Content = stringContent;
            var httpResponseMessage = await client.SendAsync(httMethod);
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
            var httMethod = await GetHttMethod(HttpMethod.Put, uri);
            var categoryAsJson = JsonSerializer.Serialize(category);
            var stringContent = new StringContent(categoryAsJson, Encoding.UTF8, "application/json");
            httMethod.Content = stringContent;
            var httpResponseMessage = await client.SendAsync(httMethod);
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
            var httMethod = await GetHttMethod(HttpMethod.Delete, $"{uri}/{id}");
            var httpResponseMessage = await client.SendAsync(httMethod);
            CheckException(httpResponseMessage);
        }
        
        private async Task<HttpRequestMessage> GetHttMethod(HttpMethod method, string uri)
        {
            var httpRequestMessage = new HttpRequestMessage(method, uri);
            var token = await sessionStorage.GetAsync<string>("token");
            if (token.Success)
            {
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            }
            //TODO add exception
            return httpRequestMessage;
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