using FoodSelling.CustomerSite.Extensions;
using FoodSelling.DTO.Dtos.CustomerSite.CategoryDtos;
using FoodSelling.CustomerSite.Interfaces;

namespace FoodSelling.CustomerSite.Services
{
    public class CategoryService : ICategory
    {
        private readonly IHttpClientFactory _clientFactory;
        public CategoryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<CategoryDto>> GetAll()
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/category/getallcategory";
            var data = httpClient.GetDataFromAPIAsync<List<CategoryDto>>(url);
            return data;
        }
    }
}
