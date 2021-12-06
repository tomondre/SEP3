using System;
using System.Threading.Tasks;
using BusinessLogic.Model.ProductCategory;
using GrpcFileGeneration.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RiskFirst.Hateoas;

namespace BusinessLogic.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet(Name = "GetCategoryRoute")]
        public async Task<ActionResult<Page<CategoryList>>>GetAllCategories([FromQuery] int page)
        {
            try
            {
                Page<CategoryList> categories = await model.GetAllCategoriesAsync(page);
                foreach (var item in categories.Content.Categories)
                {
                    if (item.Links.Count == 0)
                    {
                        await linksService.AddLinksAsync(item);
                    }
                }

                await linksService.AddLinksAsync(categories.Content);
                return Ok(categories);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
           
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id:int}",Name = "EditCategoryRoute")]
        public async Task<ActionResult<Category>> EditCategory([FromBody] Category category, [FromRoute] int id)
        {
            try
            {
                category.Id = id;
                var editProductCategoryAsync = await model.EditProductCategoryAsync(category);
                return Ok(editProductCategoryAsync);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
           
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpPost(Name = "CreateCategoryRoute")]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
        {
            try
            {
                var addProductCategoryAsync = await model.AddProductCategoryAsync(category);    
                return Ok(addProductCategoryAsync);
            }
            catch (Exception e)
            {
                return StatusCode(403, e.Message);
            }
         
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id:int}", Name = "DeleteCategoryRoute")]
        public async Task<ActionResult> DeleteProvider([FromRoute] int id)
        {
            await model.DeleteProductCategoryAsync(id);
            return Ok();
        }
    }
}