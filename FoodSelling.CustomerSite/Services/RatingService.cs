using FoodSelling.DTO.Dtos.RatingDtos;
using FoodSelling.CustomerSite.Interfaces;
using Newtonsoft.Json;

namespace FoodSelling.CustomerSite.Services
{
    public class RatingService : IRating
    {
        private readonly IHttpClientFactory _clientFactory;
        public RatingService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public Task<RatingDto> CreateRating(CreateRatingDto newRating)
        {
            throw new NotImplementedException();
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
