using FoodSelling.Backend.Interfaces;
using FoodSelling.DTO.Dtos.CustomerSite.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodSelling.Backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //Get all category
        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> GetAllCategory()
        {
            return await _categoryRepository.GetAllCategory();
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDto>> GetDetailCategory(string categoryId)
        {
            return await _categoryRepository.GetDetailCategory(categoryId);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CreateCategoryDto newCategory)
        {
            return await _categoryRepository.CreateCategory(newCategory);
        }

        [HttpDelete("{categoryId}")]
        public async Task<ActionResult<bool>> DeleteCategory (string categoryId)
        {
            return await _categoryRepository.DeleteCategory(categoryId);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDto>> UpdateCategory([FromBody] EditCategoryDto newCategory)
        {
            return await _categoryRepository.UpdateCategory(newCategory);
        }
    }
}
