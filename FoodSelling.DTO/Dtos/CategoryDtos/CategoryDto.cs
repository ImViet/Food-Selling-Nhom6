using FoodSelling.DTO.Dtos.CustomerSite.ProductDtos;

namespace FoodSelling.DTO.Dtos.CustomerSite.CategoryDtos
{
    public class CategoryDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public IList<ProductDto> Products { get; set; }
    }
}
