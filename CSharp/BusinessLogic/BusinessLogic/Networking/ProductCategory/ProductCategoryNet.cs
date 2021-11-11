using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GrpcFileGeneration.Models;
using Microsoft.JSInterop;
using Networking.Category;

namespace BusinessLogic.Networking.ProductCategory
{
    public class ProductCategoryNet : IProductCategoryNet
    {

        private CategoryService.CategoryServiceClient client;

        public ProductCategoryNet(CategoryService.CategoryServiceClient client)
        {
            this.client = client;
        }
        
        public async Task<Category> AddProductCategoryAsync(Category category)
        {
            var serialize = JsonSerializer.Serialize(category);
            var addProductCategory = await client.addProductCategoryAsync(new ProtobufMessage {MassageOrObject = serialize});
            var massageOrObject = addProductCategory.MassageOrObject;
            var deserialize = JsonSerializer.Deserialize<Category>(massageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task<IList<Category>> GetAllCategoriesAsync()
        {
            var allProductCategoriesAsync = await client.getAllProductCategoriesAsync(new ProtobufMessage());
            var massageOrObject = allProductCategoriesAsync.MassageOrObject;
            Console.WriteLine(massageOrObject);
            var deserialize = JsonSerializer.Deserialize<IList<Category>>(massageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task<Category> EditProductCategoryAsync(Category category)
        {
            var serialize = JsonSerializer.Serialize(category);
            var addProductCategoryAsync = await client.addProductCategoryAsync(new ProtobufMessage() {MassageOrObject = serialize});
            var massageOrObject = addProductCategoryAsync.MassageOrObject;
            var deserialize = JsonSerializer.Deserialize<Category>(massageOrObject, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            return deserialize;
        }

        public async Task DeleteProductCategoryAsync(int id)
        {
            await client.deleteProductCategoryAsync(new ProtobufMessage() {MassageOrObject = id.ToString()});
        }
    }
}