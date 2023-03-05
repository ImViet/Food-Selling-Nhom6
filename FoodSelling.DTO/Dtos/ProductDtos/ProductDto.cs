using FoodSelling.DTO.Dtos.RatingDtos;

namespace FoodSelling.DTO.Dtos.CustomerSite.ProductDtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }   
        public DateTime UpdatedDate { get; set; }
        public string? Description { get; set; }
        public string? Unit { get; set; }
        public string Image { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public IList<RatingDto> Ratings { get; set; }

    }
}
