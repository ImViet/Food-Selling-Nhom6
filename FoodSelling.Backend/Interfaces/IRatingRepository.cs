using FoodSelling.DTO.Dtos.RatingDtos;

namespace FoodSelling.Backend.Interfaces
{
    public interface IRatingRepository
    {
        //Task<RatingDto> CreateRating(AddRatingDTO rating);
        Task<List<RatingDto>> GetProductRatings(int id);
    }
}
