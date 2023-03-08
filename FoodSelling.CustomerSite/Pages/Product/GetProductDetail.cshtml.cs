using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos.CustomerSite.ProductDtos;
using FoodSelling.DTO.Dtos.RatingDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodSelling.CustomerSite.Pages.Product
{
    public class GetProductDetailModel : PageModel
    {
        private readonly IProduct _productService;
        private readonly IRating _ratingService;
        [BindProperty]
        public ProductDto product { get; set; } = new ProductDto();
        public GetProductDetailModel(IProduct productService, IRating ratingService)
        {
            _productService = productService;
            _ratingService = ratingService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            product = await _productService.GetProductDetail(id);
            var ratingAvg = await _productService.GetRatingAVG(id);
            ViewData["listRatings"] = await _ratingService.GetProductRatings(id);
            if (ratingAvg != 0)
            {
                ViewData["ratingAvg"] = ratingAvg;
            }
            else
            {
                ViewData["ratingAvg"] = 0;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostCreateRating()
        {
            CreateRatingDto newRating = new CreateRatingDto();
            newRating.ProductId = Int32.Parse(Request.Form["ProductId"]);
            newRating.UserName = HttpContext.Session?.GetString("UserName");
            newRating.Star = Int32.Parse(Request.Form["Star"]);
            newRating.Comment = Request.Form["Comment"];
            await _productService.CreateRating(newRating);
            return RedirectToPage(new { id = newRating.ProductId });
        }
    }
}
