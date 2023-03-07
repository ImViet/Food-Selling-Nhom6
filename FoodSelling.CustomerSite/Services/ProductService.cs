using FoodSelling.DTO.Dtos;
using FoodSelling.DTO.Dtos.CustomerSite.ProductDtos;
using FoodSelling.DTO.Dtos.RatingDtos;
using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.CustomerSite.Extensions;

namespace FoodSelling.CustomerSite.Services
{
    public class ProductService : IProduct
    {
        private readonly IHttpClientFactory _clientFactory;
        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<PagingDto<ProductDto>> GetAll(string sortOrder, int pageNumber)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getallproduct?sort={sortOrder}&pageCurrent={pageNumber}";
            var data = httpClient.GetDataFromAPIAsync<PagingDto<ProductDto>>(url);
            return data;
        }

        public async Task<PagingDto<ProductDto>> GetProductByCateId(string cateid, string sortOrder, int pageNumber)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getproductbycateid?cateid={cateid}&sort={sortOrder}&pageCurrent={pageNumber}";
            var data = httpClient.GetDataFromAPIAsync<PagingDto<ProductDto>>(url);
            return data;
        }

        public async Task<ProductDto> GetProductDetail(int id)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getproductbyid/{id}";
            var data = httpClient.GetDataFromAPIAsync<ProductDto>(url);
            return data;
        }

        public async Task<double> GetRatingAVG(int id)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/ratingavg/{id}";
            var data = httpClient.GetDataFromAPIAsync<double>(url);
            return data;
        }

        public async Task<PagingDto<ProductDto>> SearchProducts(string searchString, string sortOrder, int pageNumber)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/searchproducts?searchstring={searchString}&sort={sortOrder}&pageCurrent={pageNumber}";
            var data = httpClient.GetDataFromAPIAsync<PagingDto<ProductDto>>(url);
            return data;
        }
        public Task<RatingDto> CreateRating(CreateRatingDto newRating)
        {
            throw new NotImplementedException();
        }
    }
}
