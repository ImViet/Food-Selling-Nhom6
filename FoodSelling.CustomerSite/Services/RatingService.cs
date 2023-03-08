using FoodSelling.DTO.Dtos.RatingDtos;
using FoodSelling.CustomerSite.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace FoodSelling.CustomerSite.Services
{
    public class RatingService : IRating
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RatingService(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<RatingDto> CreateRating(CreateRatingDto newRating)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = "/rating/createrating";
            var token = _httpContextAccessor.HttpContext?.Session.GetString("JWTToken");
            var jsonString = JsonConvert.SerializeObject(newRating);
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<RatingDto>(jsonData);
            return data;
        }

        public async Task<List<RatingDto>> GetProductRatings(int id)
        {
            var httpClient = _clientFactory.CreateClient("myclient");
            string url = $"/rating/getproductratings/{id}";
            var response = httpClient.GetAsync(url).Result;
            var jsonData = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<List<RatingDto>>(jsonData);
            return data;

        }
    }
}
