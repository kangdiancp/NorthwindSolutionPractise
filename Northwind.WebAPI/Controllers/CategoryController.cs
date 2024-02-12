using Mapster;
using Microsoft.AspNetCore.Mvc;
using Northwind.Contract.Dto;
using Northwind.Domain.Entities.Master;
using Northwind.Domain.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Northwind.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IRepositoryManager _repositoryManager;

        public CategoryController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _repositoryManager.CategoryRepository.GetAllEntity(false);
            var categoryDtos = categories.Adapt<IEnumerable<CategoryDto>>();
            return Ok(categoryDtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            var category = await _repositoryManager.CategoryRepository.GetEntityById(id, false);
            if (category == null)
            {
                return NotFound();
            }
            var categoryDto = category.Adapt<CategoryDto>();
            return Ok(categoryDto);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null) 
            {
                return BadRequest("Category object is not valid");
            }
            var category = categoryDto.Adapt<Category>();
            _repositoryManager.CategoryRepository.CreateEntity(category);
            _repositoryManager.UnitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);

        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody]CategoryDto categoryDto)
        {
            var category = await _repositoryManager.CategoryRepository.GetEntityById(id, true);
            if (category == null)
            {
                return NotFound();
            }
            category.CategoryName = categoryDto.CategoryName;
            category.Description = categoryDto.Description;
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _repositoryManager.CategoryRepository.GetEntityById(id, false);
            if (category == null)
            {
                return NotFound();
            }

            _repositoryManager.CategoryRepository.DeleteEntity(category);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
