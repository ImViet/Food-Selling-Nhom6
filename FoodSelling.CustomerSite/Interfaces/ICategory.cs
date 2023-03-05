using FoodSelling.DTO.Dtos.CustomerSite.CategoryDtos;

namespace FoodSelling.CustomerSite.Interfaces
{
    public interface ICategory
    {
        Task<List<CategoryDto>> GetAll();
    }
}
