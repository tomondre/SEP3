﻿using System;
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
            var httpRequest = await GetHttpRequest(HttpMethod.Post, uri);
            var categoryAsJson = JsonSerializer.Serialize(category);
            var stringContent = new StringContent(categoryAsJson, Encoding.UTF8, "application/json");
            httpRequest.Content = stringContent;
            var httpResponseMessage = await client.SendAsync(httpRequest);
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var deserialize = JsonSerializer.Deserialize<Category>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task<Page<CategoryList>> GetAllCategoriesAsync(int page)
        {
            var httpRequest = await GetHttpRequest(HttpMethod.Get, $"{uri}?page={page}");
            var httpResponseMessage = await client.SendAsync(httpRequest);
            CheckException(httpResponseMessage);
            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
            var categories = JsonSerializer.Deserialize<Page<CategoryList>>(readAsStringAsync, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return categories;
        }

        public async Task<Category> EditProductCategoryAsync(Category category)
        {
            var httpRequest = await GetHttpRequest(HttpMethod.Patch, $"{uri}/{category.Id}");
            var categoryAsJson = JsonSerializer.Serialize(category);
            var stringContent = new StringContent(categoryAsJson, Encoding.UTF8, "application/json");
            httpRequest.Content = stringContent;
            var httpResponseMessage = await client.SendAsync(httpRequest);
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
            var httpRequest = await GetHttpRequest(HttpMethod.Delete, $"{uri}/{id}");
            var httpResponseMessage = await client.SendAsync(httpRequest);
            CheckException(httpResponseMessage);
        }
        
        private async Task<HttpRequestMessage> GetHttpRequest(HttpMethod method, string uri)
        {
            var httpRequest = new HttpRequestMessage(method, uri);
            var token = await sessionStorage.GetAsync<string>("token");
            if (token.Success)
            {
                httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            }
            //TODO add exception
            return httpRequest;
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