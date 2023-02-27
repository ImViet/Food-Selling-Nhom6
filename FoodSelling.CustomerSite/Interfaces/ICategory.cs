using FoodSelling.DTO.Dtos.CustomerSite.CategoryDtos;

namespace RAShop.CustomerSite.Interfaces
{
    public interface ICategory 
    {
        Task<List<CategoryDto>> GetAll();
    }
}
