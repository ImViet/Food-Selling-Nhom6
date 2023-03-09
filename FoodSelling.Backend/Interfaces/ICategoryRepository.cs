using FoodSelling.DTO.Dtos.CustomerSite.CategoryDtos;

namespace FoodSelling.Backend.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllCategory();
        Task<CategoryDto> GetDetailCategory(string categoryId);
        Task<CategoryDto> CreateCategory(CreateCategoryDto newCategory);
        Task<bool> DeleteCategory(string categoryId);
        Task<CategoryDto> UpdateCategory(EditCategoryDto newCategory);
    }
}
