using AutoMapper;
using FoodSelling.Backend.Data;
using FoodSelling.Backend.Entities;
using FoodSelling.Backend.Interfaces;
using FoodSelling.DTO.Dtos.RatingDtos;
using Microsoft.EntityFrameworkCore;

namespace FoodSelling.Backend.Repositories
{
    public class RatingRepository: IRatingRepository
    {
        private readonly FoodSellingDbContext _context;
        private readonly IMapper _mapper;
        public RatingRepository(FoodSellingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<RatingDto>> GetProductRatings(int id)
        {
            var rating = await _context.Ratings.Where(x => x.ProductId == id).OrderByDescending(p => p.CreatedDate).ToListAsync();
            var listRatingDTO = _mapper.Map<List<RatingDto>>(rating);
            return listRatingDTO;
        }
        //public async Task<RatingDto> CreateRating(AddRatingDTO newRating)
        //{
        //    var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == newRating.ProductId);
        //    Rating rating = new Rating();
        //    if (product != null)
        //    {
        //        rating = _mapper.Map<Rating>(newRating);
        //        _context.Ratings.Add(rating);
        //    }
        //    await _context.SaveChangesAsync();
        //    return _mapper.Map<RatingDTO>(rating);
        //}
    }
}
