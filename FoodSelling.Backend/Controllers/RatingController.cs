﻿using FoodSelling.Backend.Interfaces;
using FoodSelling.DTO.Dtos.RatingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodSelling.Backend.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepository;
        public RatingController(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        [HttpGet("{id}")]
        public async Task<List<RatingDto>> GetProductRatings(int id)
        {
            return await _ratingRepository.GetProductRatings(id);
        }
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "User")]
        [HttpPost]
        public async Task<RatingDto> CreateRating(CreateRatingDto newRating)
        {
            return await _ratingRepository.CreateRating(newRating);
        }
    }
}
