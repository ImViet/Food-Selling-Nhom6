using FoodSelling.DTO.Dtos.RatingDtos;
using RAShop.CustomerSite.Interfaces;

namespace FoodSelling.CustomerSite.Services
{
    public class RatingService : IRating
    {
        public Task<RatingDto> CreateRating(CreateRatingDto newRating)
        {
            throw new NotImplementedException();
        }

        public Task<List<RatingDto>> GetProductRatings(int id)
        {
            throw new NotImplementedException();
        }
    }
}
