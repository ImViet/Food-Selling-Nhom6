using FoodSelling.DTO.Dtos;
using FoodSelling.DTO.Dtos.CustomerSite.ProductDtos;

namespace FoodSelling.Backend.Interfaces
{
    public interface IProductRepository
    {
        Task<PagingDto<ProductDto>> GetAllProduct(string sortOrder, int pageNumber, int pageSize);
        Task<ProductDto> GetProductById(int id);
        Task<PagingDto<ProductDto>> GetProductByCateId(string cateId, string sortOrder, int pageNumber, int pageSize);
        Task<PagingDto<ProductDto>> SearchProducts(string searchString, string sortOrder, int pageNumber, int pageSize);
        Task<double> RatingAVG(int id);

    }
}
