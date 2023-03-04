using FoodSelling.DTO.Dtos.CustomerSite.CategoryDtos;

namespace FoodSelling.Backend.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllCategory();
    }
}
