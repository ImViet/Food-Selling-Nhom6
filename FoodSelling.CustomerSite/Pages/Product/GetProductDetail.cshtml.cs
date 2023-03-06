using FoodSelling.CustomerSite.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodSelling.CustomerSite.Pages.Product
{
    public class GetProductDetailModel : PageModel
    {
        private readonly IProduct _productService;
        private readonly IRating _ratingService;
        public GetProductDetailModel(IProduct productService, IRating ratingService)
        {
            _productService = productService;
            _ratingService = ratingService;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _productService.GetProductDetail(id);
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
            ViewData["product"] = product;
            return Page();
        }
    }
}
