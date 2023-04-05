using FoodSelling.DTO.Dtos;
using FoodSelling.DTO.Dtos.CustomerSite.ProductDtos;
using FoodSelling.DTO.Dtos.RatingDtos;
using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.CustomerSite.Extensions;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace FoodSelling.CustomerSite.Services
{
    public class ProductService : IProduct
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductService(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<PagingDto<ProductDto>> GetAll(string sortOrder, int pageNumber)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = $"/product/getallproduct?sort={sortOrder}&pageCurrent={pageNumber}";
            var data = httpClient.GetDataFromAPIAsync<PagingDto<ProductDto>>(url);
            return data;
        }
        public async Task<int> CountProduct()
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            var url = "/product/countproduct";
            var data = httpClient.GetDataFromAPIAsync<int>(url);
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
        public async Task<RatingDto> CreateRating(CreateRatingDto newRating)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/rating/createrating";
            var token = _httpContextAccessor.HttpContext?.Session.GetString("JWTToken");
            var jsonString = JsonConvert.SerializeObject(newRating);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsync(url, content);
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<RatingDto>(jsonData);
            return data;
        }

        public async Task<ProductDto> CreateProduct(CreateProductDto newProduct)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/product/createproduct";
            var token = _httpContextAccessor.HttpContext?.Session.GetString("JWTToken");
            var jsonString = JsonConvert.SerializeObject(newProduct);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await httpClient.PostAsync(url, content);
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<ProductDto>(jsonData);
            return data;
        }
    }
}
