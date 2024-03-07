using Mapster;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Mvc;
using Northwind.Contract.Dto;
using Northwind.Domain.Entities.Master;
using Northwind.Domain.Repositories;
using Northwind.Domain.RequestFeature;
using Northwind.Service.Abstraction.Base;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.WebAPI.Controllers
{
    [Route("api/categorysrv")]
    [ApiController]
    public class CategoryServiceController : ControllerBase
    {

        private readonly IServiceManager _serviceManager;

        public CategoryServiceController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categoryDtos = await _serviceManager.CategoryService.GetAllAsync(false);
            return Ok(categoryDtos);
        }

        [HttpGet("paging")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesPaging(
            [FromQuery] EntityParameter entityParameter)
        {
            var categoryDtos = await _serviceManager.CategoryService.GetAllPagingAsync(entityParameter,false);
            return Ok(categoryDtos);
        }


        [HttpGet("{id}")]
        [HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 120)]
        [HttpCacheValidation(MustRevalidate = false)]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            var categoryDto = await _serviceManager.CategoryService.GetyByIdAsync(id,false);
            if(categoryDto == null)
            {
                return NotFound();
            }
            return Ok(categoryDto);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            var category = await _serviceManager.CategoryService.CreateAsync(categoryDto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody]CategoryDto categoryDto)
        {
            await _serviceManager.CategoryService.UpdateAsync(id,categoryDto);
            
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceManager.CategoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}
