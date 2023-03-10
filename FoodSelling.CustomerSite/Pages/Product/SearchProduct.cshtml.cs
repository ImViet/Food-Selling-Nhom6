using FoodSelling.CustomerSite.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodSelling.CustomerSite.Pages.Product
{
    public class SearchProductModel : PageModel
    {
        private readonly IProduct _productService;
        private readonly ICategory _categoryService;
        public SearchProductModel(IProduct productService, ICategory categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> OnGetAsync(string sortOrder = "0", int pageCurrent = 1)
        {
            if (pageCurrent > 1)
            {
                ViewData["page"] = pageCurrent;
            }
            else
            {
                ViewData["page"] = 1;
            }
            if (sortOrder != "0")
            {
                ViewData["sort"] = sortOrder;
            }
            else
            {
                ViewData["sort"] = "0";
            }
            var searchString = Request.Query["searchString"];
            var data = await _productService.SearchProducts(searchString, sortOrder, pageCurrent);
            ViewData["totalPages"] = data.TotalPages;
            ViewData["searchString"] = searchString;
            ViewData["products"] = data.Items;
            return Page();
        }
    }
}
