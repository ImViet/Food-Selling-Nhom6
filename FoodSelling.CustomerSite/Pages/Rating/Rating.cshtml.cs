using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos;
using FoodSelling.DTO.Dtos.RatingDtos;

namespace RAShop.CustomerSite.Pages.Home
{
    public class Rating : PageModel
    {
        private readonly IRating _ratingService;
        public Rating(IRating ratingService)
        {
            _ratingService = ratingService;
        }
        public async Task<IActionResult> OnGetCreateRating()
        {
            CreateRatingDto newRating = new CreateRatingDto();
            newRating.ProductId = Int32.Parse(Request.Form["ProductId"]);
            newRating.UserName = HttpContext.Session?.GetString("UserName");
            newRating.Star = Int32.Parse(Request.Form["Star"]);
            newRating.Comment = Request.Form["Comment"];
            await _ratingService.CreateRating(newRating);
            return Page();
        }
    }
}