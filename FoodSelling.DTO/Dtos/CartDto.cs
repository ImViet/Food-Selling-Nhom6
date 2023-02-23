using FoodSelling.DTO.Dtos.CustomerSite.ProductDtos;

namespace FoodSelling.DTO.Dtos
{
    public class CartDto
    {
        public int Quantity { get; set; }
        public ProductDto Product { get; set; }
        public double Total
        {
            get { return Quantity * (double)Product.Price; }
        }
    }
}
