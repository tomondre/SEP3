using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogic.Model.ProductCategory;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;

namespace BusinessLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        private IProductCategoryModel model;
        private ILinksService linksService;

        public ProductCategoryController(IProductCategoryModel model, ILinksService linksService)
        {
            this.model = model;
            this.linksService = linksService;
        }

        [HttpGet(Name = "GetCategoryRoute")]
        public async Task<ActionResult<CategoryList>>GetAllCategories()
        {
            CategoryList list = new CategoryList();
            list.Categories = await model.GetAllCategoriesAsync();
            foreach (var item in list.Categories)
            {
                await linksService.AddLinksAsync(item);
            }

            await linksService.AddLinksAsync(list);
            
            return Ok(list);
        }
        
        [HttpGet("{id:int}", Name = "GetCategoryByIdRoute")]
   
        public async Task<ActionResult<CategoryList>>GetCategoryById([FromRoute] int id)
        {
            CategoryList list = new CategoryList();
            list.Categories = await model.GetAllCategoriesAsync();
            foreach (var item in list.Categories)
            {
                await linksService.AddLinksAsync(item);
            }

            await linksService.AddLinksAsync(list);
            
            return Ok(list);
        }
        
        [HttpPut("{id:int}",Name = "EditCategoryRoute")]
        public async Task<ActionResult<Category>> EditCategory([FromBody] Category category, [FromRoute] int id)
        {
            category.Id = id;
            var editProductCategoryAsync = await model.EditProductCategoryAsync(category);
            return Ok(editProductCategoryAsync);
        }
        
        [HttpPost(Name = "CreateCategoryRoute")]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
        {
            var addProductCategoryAsync = await model.AddProductCategoryAsync(category);    
            return Ok(addProductCategoryAsync);
        }
        
        [HttpDelete("{id:int}", Name = "DeleteCategoryRoute")]
        public async Task<ActionResult> DeleteProvider([FromRoute] int id)
        {
            await model.DeleteProductCategoryAsync(id);
            return Ok();
        }
    }
}