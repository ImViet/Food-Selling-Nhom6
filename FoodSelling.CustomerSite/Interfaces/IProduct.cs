using FoodSelling.DTO.Dtos;
using FoodSelling.DTO.Dtos.CustomerSite.ProductDtos;
using FoodSelling.DTO.Dtos.RatingDtos;
using Microsoft.AspNetCore.Mvc;

namespace FoodSelling.CustomerSite.Interfaces
{
    public interface IProduct
    {
        Task<PagingDto<ProductDto>> GetAll(string sortOrder, int pageNumber);
        Task<PagingDto<ProductDto>> GetProductByCateId(int id, string sortOrder, int pageNumber);
        Task<PagingDto<ProductDto>> GetProductBySubCateId(int id, string sortOrder, int pageNumber);
        Task<PagingDto<ProductDto>> SearchProducts(string searchString, string sortOrder, int pageNumber);
        Task<ProductDto> GetProductDetail(int id);
        Task<double> GetRatingAVG(int id);
        Task<RatingDto> CreateRating(CreateRatingDto newRating);


    }
}