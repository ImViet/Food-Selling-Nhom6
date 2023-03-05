using FoodSelling.DTO.Dtos;
using FoodSelling.DTO.Dtos.CustomerSite.ProductDtos;
using FoodSelling.DTO.Dtos.RatingDtos;
using FoodSelling.CustomerSite.Interfaces;

namespace FoodSelling.CustomerSite.Services
{
    public class ProductService : IProduct
    {
        public Task<RatingDto> CreateRating(CreateRatingDto newRating)
        {
            throw new NotImplementedException();
        }

        public Task<PagingDto<ProductDto>> GetAll(string sortOrder, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public Task<PagingDto<ProductDto>> GetProductByCateId(int id, string sortOrder, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public Task<PagingDto<ProductDto>> GetProductBySubCateId(int id, string sortOrder, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetProductDetail(int id)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetRatingAVG(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagingDto<ProductDto>> SearchProducts(string searchString, string sortOrder, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
