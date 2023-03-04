using FoodSelling.Backend.Interfaces;
using FoodSelling.DTO.Dtos.CustomerSite.CategoryDtos;
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
    }
}
