using FoodSelling.DTO.Dtos.RatingDtos;

namespace FoodSelling.CustomerSite.Interfaces
{
    public interface IRating
    {
        Task<RatingDto> CreateRating(CreateRatingDto newRating);
        Task<List<RatingDto>> GetProductRatings(int id);
    }
}